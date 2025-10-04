using System.Diagnostics;
using System.Threading.Channels;

class Program
{
    static void MethodA()
    {
        Console.WriteLine("MethodA");
        MethodB();
    }

    static void MethodB()
    {
        Console.WriteLine("MethodB");
        MethodC();
    }

    static void MethodC()
    {
        try
        {
            throw new DivideByZeroException();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Деление на ноль но ток не настоящее");
            LogCallStack(ex);
        }

    }

    static void LogCallStack(Exception ex)
    {
        string logPath = "callstack_log.txt";
        string logMessage =
            $@"{Environment.NewLine}Время: {DateTime.Now}
            Сообщение исключения: {ex.Message}
            Тип исключения: {ex.GetType().Name}
            Полная информация: {ex}";
        File.AppendAllText(logPath, logMessage);
    }

    static void Main()
    {
        MethodA();
    }
}