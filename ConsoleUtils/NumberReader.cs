using System;

namespace Folleach.ConsoleUtils
{
    public static class NumberReader<T>
    {
        public delegate bool TryParseDelegate(string text, out T value);

        public static T ReadUntilNoResult(string prefix, TryParseDelegate parser)
        {
            while (true)
            {
                WritePrefix(prefix);
                if (parser(Console.ReadLine(), out T value))
                    return value;
            }
        }

        public static T ReadOrDefault(string prefix, TryParseDelegate parser)
        {
            WritePrefix(prefix);
            if (parser(Console.ReadLine(), out T value))
                return value;
            return default;
        }

        private static void WritePrefix(string prefix)
        {
            if (prefix != null)
                Console.Write($"{prefix}: ");
        }
    }
}
