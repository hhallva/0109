using NLog;

internal class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    private static void Main()
    {
        Console.WriteLine("Калькулятор деления двух чисел");

        try
        {
            Console.Write("Введите первое число: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            if (number2 == 0)
                throw new DivideByZeroException("Деление на ноль запрещено.");

            double result = number1 / number2;

            Console.WriteLine($"\nРезультат: {number1} / {number2} = {result}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Ошибка: Введите корректные числа!");
            logger.Error(ex, "FormatException: Введено нечисловое значение.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Ошибка: Деление на ноль запрещено.");
            logger.Error(ex, "DivideByZeroException: Попытка деления на ноль.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка.");
            Console.WriteLine($"Stack Trace:\n{ex.StackTrace}");
            logger.Error(ex, "Необработанное исключение.");
        }
        finally
        {
            
            LogManager.Shutdown();
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}