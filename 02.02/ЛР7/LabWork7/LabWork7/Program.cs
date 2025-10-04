using System;
using System.IO;

namespace LabWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число:");
            string input1 = Console.ReadLine();

            Console.WriteLine("Введите второе число:");
            string input2 = Console.ReadLine();

            try
            {
                // Преобразуем строки в числа
                double num1 = double.Parse(input1);
                double num2 = double.Parse(input2);

                // Сложение
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

        // Метод для логирования исключений в файл
        static void LogException(Exception ex)
        {
            string logFilePath = "10g.txt";
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().Name}: {ex.Message}{Environment.NewLine}";

            try
            {
                File.AppendAllText(logFilePath, logMessage);
            }
            catch (Exception logEx)
            {
                // На случай, если не удастся записать в лог (например, нет прав)
                Console.WriteLine($"Не удалось записать в лог: {logEx.Message}");
            }
        }
    }
}