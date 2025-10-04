using System;
using System.Diagnostics;

namespace Task4
{
    class Program
    {
        private static readonly TraceSwitch AppSwitch = new TraceSwitch("DataOperationsSwitch", "Управляет детализацией логов операций с данными");

        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Trace.Listeners.Add(new TextWriterTraceListener("app.log", "fileListener"));
            Trace.AutoFlush = true;

            Console.WriteLine($"Текущий уровень логирования: {AppSwitch.Level}");
            Console.WriteLine("Выполняются операции...\n");

            LoadData();
            SaveData();
            DeleteData();

            Trace.Flush();
            Trace.Close();

            Console.WriteLine("\nОперации завершены. Проверьте app.log.");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void LoadData()
        {
            if (AppSwitch.TraceVerbose)
                Trace.WriteLine("VERBOSE: Начало загрузки данных из источника...");

            if (AppSwitch.TraceInfo)
                Trace.WriteLine("INFO: Подключение к хранилищу данных...");

            System.Threading.Thread.Sleep(100);

            if (AppSwitch.TraceWarning)
                Trace.WriteLine("WARNING: Некоторые поля имеют устаревший формат.");

            if (AppSwitch.TraceError)
                Trace.WriteLine("ERROR: Не удалось загрузить 2 записи (пропущено).");

            if (AppSwitch.TraceInfo)
                Trace.WriteLine("INFO: Загрузка завершена. Загружено 150 записей.");
        }

        static void SaveData()
        {
            if (AppSwitch.TraceVerbose)
                Trace.WriteLine("VERBOSE: Подготовка данных к сохранению...");

            if (AppSwitch.TraceInfo)
                Trace.WriteLine("INFO: Сохранение данных в файл storage.dat...");

            System.Threading.Thread.Sleep(80);

            if (AppSwitch.TraceWarning)
                Trace.WriteLine("WARNING: Файл перезаписан. Резервная копия не создана.");

            if (AppSwitch.TraceInfo)
                Trace.WriteLine("INFO: Данные успешно сохранены.");
        }

        static void DeleteData()
        {
            if (AppSwitch.TraceVerbose)
                Trace.WriteLine("VERBOSE: Проверка прав доступа перед удалением...");

            if (AppSwitch.TraceInfo)
                Trace.WriteLine("INFO: Удаление временных файлов...");

            System.Threading.Thread.Sleep(50);

            if (AppSwitch.TraceError)
                Trace.WriteLine("ERROR: Не удалось удалить файл temp.cache (доступ запрещён).");

            if (AppSwitch.TraceInfo)
                Trace.WriteLine("INFO: Удаление завершено.");
        }
    }
}