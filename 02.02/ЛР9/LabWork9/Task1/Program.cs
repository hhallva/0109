using System.Diagnostics;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        string filePath = "data.txt";
       
        Console.ForegroundColor = ConsoleColor.Green;
        await Profiler.ProfileReading(filePath);
    }
}

public class Project
{ 
    public void ReadFromFile(string filePath)
    {
        Console.ForegroundColor = ConsoleColor.Red;

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    public async Task ReadFromFileAsync(string filePath, int bufferSize = 8192)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        using var fileStream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.Read,
            bufferSize,
            useAsync: true);

        using var reader = new StreamReader(fileStream, bufferSize: bufferSize);

        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            Console.WriteLine(line);
        }
          
    }
}

public static class Profiler
{
    public static async Task ProfileReading(string filePath)
    {
        var project = new Project();

        //синхронный метод
        var stopwatch = Stopwatch.StartNew();
        project.ReadFromFile(filePath);
        stopwatch.Stop();

        long syncMs = stopwatch.ElapsedMilliseconds;

        //асинхронныый метод
        stopwatch.Restart();

        await project.ReadFromFileAsync(filePath, bufferSize: 8192);
        stopwatch.Stop();
        long asyncMs = stopwatch.ElapsedMilliseconds;

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("\n=== РЭЗУЙЛЬТАУТЫ ===");
        Console.WriteLine($"Синхроунный метод:   {syncMs} мс");
        Console.WriteLine($"Асинхроунный метод:  {asyncMs} мс");
        Console.WriteLine($"Раузница:            {syncMs - asyncMs} мс");
        Console.ResetColor();
    }
}