using System;
using System.Text;

namespace Folleach.ConsoleUtils
{
    public static class ExtendedConsole
    {
        private const string DefaultPattern = "<message>\r\n<stacktrace>";

        public static void WriteException(Exception exception, ConsoleColor color = ConsoleColor.Gray, string pattern = DefaultPattern)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(pattern.Replace("<message>", exception.Message).Replace("<stacktrace>", exception.StackTrace));
            Console.ForegroundColor = oldColor;
        }

        public static void WriteLineRepeat(string value, int copies)
        {
            var builder = new StringBuilder(value.Length * copies);
            for (var i = 0; i < copies; i++)
                builder.Append(value);
            Console.WriteLine(builder.ToString());
        }
        
        public static void SetupUTF8()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
        }
    }
}
