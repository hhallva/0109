// Task4

class Program
{
    static void Main()
    {
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

        throw new InvalidOperationException("Тестовая критическая ошибка!");
    }

    static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        var exception = e.ExceptionObject as Exception;

        string logMessage = $"[CRASH] {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                            $"Тип: {exception?.GetType().FullName}\n" +
                            $"Сообщение: {exception?.Message}\n" +
                            $"Стек: {exception?.StackTrace}\n" +
                            new string('-', 50) + "\n";

        try
        {
            File.AppendAllText("crash.log", logMessage);
        }
        catch
        {
            // Игнорируем ошибки записи лога — иначе рекурсия
        }

        Console.WriteLine("Произошла ошибка. Подробности в логах.");

        // Задержка, чтобы пользователь успел прочитать сообщение (опционально)
        Thread.Sleep(2000);
    }
}