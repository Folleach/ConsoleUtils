using Folleach.ConsoleUtils;
using System;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = NumberReader<int>.ReadUntilNoResult("x", int.TryParse);
            WriteVariable(x);
            int y = NumberReader<int>.ReadOrDefault("y", int.TryParse);
            WriteVariable(y);
        }

        private static void WriteVariable(object value)
        {
            Console.WriteLine($"{value.GetType().Name} equals is {value}");
        }
    }
}
