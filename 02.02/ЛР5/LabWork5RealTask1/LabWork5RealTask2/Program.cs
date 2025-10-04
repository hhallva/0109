using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Калькулятор суммы двух чисел\n");
        string command = "";
        try
        {
            Debug.WriteLine("Перед первым числоум DEBUG");
            Trace.WriteLine("Перед первым числоум TRACE");
            Console.Write("Введите первое число: ");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Debug.WriteLine("Перед вторым числоум DEBUG");
            Trace.WriteLine("Перед вторым числоу23" + "м TRACE");
            Console.Write("Введите второе число: ");
            double number2 = Convert.ToDouble(Console.ReadLine());

            double sum = number1 + number2;

            Debug.WriteLine("Перед выводоум результаута DEBUG");
            Trace.WriteLine("Перед выводоум результаута TRACE");
            Console.WriteLine($"\nРезультат: {number1} + {number2} = {sum}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введите корректные числа!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    
    }
}