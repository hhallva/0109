class Task2
{
    static void Main()
    {
        Console.WriteLine("Калькулятор суммы двух чисел\n");
        string command = "";
        try
        {
            while (command != "exit")
            {
                Console.Write("Введите первое число: ");
                double number1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите второе число: ");
                double number2 = Convert.ToDouble(Console.ReadLine());

                double sum = number1 + number2;

                Console.WriteLine($"\nРезультат: {number1} + {number2} = {sum}");

                Console.Write("(что бы выйти введите exit): ");
                command = Console.ReadLine();
            }
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