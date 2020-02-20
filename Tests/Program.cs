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
            int? z = NumberReader<int>.ReadOrNull("z", int.TryParse);
            WriteVariable(z);
        }

        private static void WriteVariable(object value)
        {
            if (value == null)
            {
                Console.WriteLine("null");
                return;
            }
            Console.WriteLine($"{value.GetType().Name} equals is {value}");
        }
    }
}
