using System;
using System.Diagnostics;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.AutoFlush = true;

            Stopwatch totalStopwatch = Stopwatch.StartNew();

            Stopwatch sw1 = Stopwatch.StartNew();
            ProcessFileData();
            sw1.Stop();
            Trace.WriteLine($"[Операция 1] Чтение и обработка файла: {sw1.ElapsedMilliseconds} мс");

            Stopwatch sw2 = Stopwatch.StartNew();
            double result = ComputeMathHeavyTask(500000);
            sw2.Stop();
            Trace.WriteLine($"[Операция 2] Математические вычисления: {sw2.ElapsedMilliseconds} мс");

            Stopwatch sw3 = Stopwatch.StartNew();
            SortLargeArray(200000);
            sw3.Stop();
            Trace.WriteLine($"[Операция 3] Сортировка массива: {sw3.ElapsedMilliseconds} мс");

            totalStopwatch.Stop();
            Trace.WriteLine($"[ИТОГО] Общее время выполнения: {totalStopwatch.ElapsedMilliseconds} мс");

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        static void ProcessFileData()
        {
            string fileName = "numbers.txt";

            if (!File.Exists(fileName))
            {
                Random rand = new Random();
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    for (int i = 0; i < 1000; i++)
                        writer.WriteLine(rand.Next(1, 100000));
                }
            }

            string[] lines = File.ReadAllLines(fileName);
            long sum = 0;
            foreach (string line in lines)
            {
                if (long.TryParse(line, out long num))
                   sum += num;
                
            }
        }

        static double ComputeMathHeavyTask(int iterations)
        {
            double total = 0.0;
            for (int i = 0; i < iterations; i++)
                total += Math.Sqrt(i + 1);
            
            return total;
        }

        static void SortLargeArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rand.Next();
            
            Array.Sort(array);
        }
    }
}