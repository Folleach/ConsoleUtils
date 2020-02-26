using System;

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
    }
}
