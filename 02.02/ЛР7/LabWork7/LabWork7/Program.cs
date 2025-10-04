using System;
using System.IO;

namespace LabWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число:");
            string input1 = Console.ReadLine();

            Console.Write("Введите второе число:");
            string input2 = Console.ReadLine();

            try
            {
                double num1 = double.Parse(input1);
                double num2 = double.Parse(input2);

                double sum = num1 + num2;

                Console.WriteLine($"Сумма: {sum}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка формата: введено нечисловое значение.");
                LogException(ex);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Ошибка переполнения: результат слишком велик.");
                LogException(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                LogException(ex);
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void LogException(Exception ex)
        {
            string logFilePath = "log.txt";
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().Name}: {ex.Message}{Environment.NewLine}";

            try
            {
                File.AppendAllText(logFilePath, logMessage);
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Не удалось записать в лог: {logEx.Message}");
            }
        }
    }
}