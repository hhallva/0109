using Task2;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите ваш возраст: ");
            string input = Console.ReadLine();

            int age = int.Parse(input);

            if (age < 0)
                throw new NegativeNumberException("Возраст не может быть отрицательным.");
      

            Console.WriteLine($"Спасибо! Ваш возраст: {age} лет.");
        }
        catch (NegativeNumberException ex)
        {
            Console.WriteLine($"Ошибка ввода: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: пожалуйста, введите корректное целое число.");
        }
        catch (Exception ex)
        {
        
            Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
        }

        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}