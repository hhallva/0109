// Task3
class Program
{
    static void Main()
    {
        string filePath = "numbers.txt";

        try
        {
            using var reader = new StreamReader(filePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Предполагаем, что числа разделены пробелами или новыми строками
                var numbers = line.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .Where(n => n % 2 == 0);

                foreach (var even in numbers)
                {
                    Console.WriteLine($"Чётное число: {even}");
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Файл не найден: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
        }
        // Файл автоматически закроется благодаря 'using'
    }
}