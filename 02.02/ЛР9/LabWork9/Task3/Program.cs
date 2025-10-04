using System.Diagnostics;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var project = new Project();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Запуск профилирования вычисления Фибоначчи...\n");

        await Profiler.ProfileFibonacci(project, 40);
    }
}

public class Project
{
    private readonly Dictionary<int, int> _fibonacciCache = new Dictionary<int, int>();

    public int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    public int FibonacciFast(int n)
    {
        if (n <= 1)
            return n;

        if (_fibonacciCache.TryGetValue(n, out int cachedValue))
            return cachedValue;
        

        int result = FibonacciFast(n - 1) + FibonacciFast(n - 2);

        _fibonacciCache[n] = result;

        return result;
    }
}

public static class Profiler
{
    public static async Task ProfileFibonacci(Project project, int count)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Вычисление (без кэша):");
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < count; i++)
        {
            int value = project.Fibonacci(i);
            Console.WriteLine($"Fib({i}) = {value}");
        }
        stopwatch.Stop();
        long naiveMs = stopwatch.ElapsedMilliseconds;

        Console.WriteLine("\n" + new string('=', 40) + "\n");

        project = new Project();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Вычисление (с кэшированием):");
        stopwatch.Restart();
        for (int i = 0; i < count; i++)
        {
            int value = project.FibonacciFast(i);
            Console.WriteLine($"Fib({i}) = {value}");
        }
        stopwatch.Stop();
        long optimizedMs = stopwatch.ElapsedMilliseconds;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== Результаты профилирования вычислений ===");
        Console.WriteLine($"Без кэширования:    {naiveMs} мс");
        Console.WriteLine($"С кэшированием:     {optimizedMs} мс");
        Console.WriteLine($"Ускорение:          {naiveMs - optimizedMs} мс");
        Console.ResetColor();
    }
}