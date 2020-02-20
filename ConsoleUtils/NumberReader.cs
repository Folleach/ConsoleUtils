using System;

namespace Folleach.ConsoleUtils
{
    /// <summary>
    /// Reads a number from the console
    /// </summary>
    /// <typeparam name="T">Type to read</typeparam>
    public static class NumberReader<T> where T : struct
    {
        /// <summary>
        /// Delegate for parsing
        /// </summary>
        /// <param name="text">Input value</param>
        /// <param name="value">Output value</param>
        /// <returns>Returns logical success value</returns>
        public delegate bool TryParseDelegate(string text, out T value);

        /// <summary>
        /// Reads until the valid value is read
        /// </summary>
        /// <param name="prefix">It will be written at the beginning</param>
        /// <param name="parser">Parser method</param>
        /// <returns>Returns a valid read value</returns>
        public static T ReadUntilNoResult(string prefix, TryParseDelegate parser)
        {
            while (true)
            {
                WritePrefix(prefix);
                if (parser(Console.ReadLine(), out T value))
                    return value;
            }
        }

        /// <summary>
        /// Reads a value or default value if input text will be invalid
        /// </summary>
        /// <param name="prefix">It will be written at the beginning</param>
        /// <param name="parser">Parser method</param>
        /// <returns>Returns a value or default value if input text will be invalid</returns>
        public static T ReadOrDefault(string prefix, TryParseDelegate parser)
        {
            WritePrefix(prefix);
            if (parser(Console.ReadLine(), out T value))
                return value;
            return default;
        }

        /// <summary>
        /// Reads a value or null value if input text will be invalid
        /// </summary>
        /// <param name="prefix">It will be written at the beginning</param>
        /// <param name="parser">Parser method</param>
        /// <returns>Returns a value or null value if input text will be invalid</returns>
        public static T? ReadOrNull(string prefix, TryParseDelegate parser)
        {
            WritePrefix(prefix);
            if (parser(Console.ReadLine(), out T value))
                return value;
            return null;
        }

        private static void WritePrefix(string prefix)
        {
            if (prefix != null)
                Console.Write($"{prefix}: ");
        }
    }
}
