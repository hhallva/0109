using System;
using System.Diagnostics;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileListener = new TextWriterTraceListener("Log.txt", "fileListener");
            Trace.Listeners.Add(fileListener);
            Trace.AutoFlush = false; 

            Console.WriteLine("=== Калькулятор с логированием ===");
            Console.Write("Введите первое число: ");
            string input1 = Console.ReadLine();

            Console.Write("Введите второе число: ");
            string input2 = Console.ReadLine();

            double a, b;
            bool validInput = true;

            if (!double.TryParse(input1, out a))
            {
                Trace.WriteLine($"[ОШИБКА] Некорректное первое число: \"{input1}\"");
                Console.WriteLine("Ошибка: первое значение не является числом.");
                validInput = false;
            }

            if (!double.TryParse(input2, out b))
            {
                Trace.WriteLine($"[ОШИБКА] Некорректное второе число: \"{input2}\"");
                Console.WriteLine("Ошибка: второе значение не является числом.");
                validInput = false;
            }

            if (validInput)
            {
                double sum = Add(a, b);
                Trace.WriteLine($"[ОПЕРАЦИЯ] Сложение: {a} + {b} = {sum}");
                Console.WriteLine($"Сумма: {a} + {b} = {sum}");

                double diff = Subtract(a, b);
                Trace.WriteLine($"[ОПЕРАЦИЯ] Вычитание: {a} - {b} = {diff}");
                Console.WriteLine($"Разность: {a} - {b} = {diff}");

                try
                {
                    double quotient = Divide(a, b);
                    Trace.WriteLine($"[ОПЕРАЦИЯ] Деление: {a} / {b} = {quotient}");
                    Console.WriteLine($"Частное: {a} / {b} = {quotient}");
                }
                catch (DivideByZeroException ex)
                {
                    Trace.WriteLine($"[ОШИБКА] Деление на ноль: {a} / {b} → {ex.Message}");
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("\nОперации завершены. Лог сохранён в Log.txt.");

            Trace.Flush();
            Trace.Close();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Divide(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("Делитель не может быть равен нулю.");
            return x / y;
        }
    }
}