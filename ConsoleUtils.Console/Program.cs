using System;
using Folleach.ConsoleUtils;

ExtendedConsole.SetupUTF8();
if (args.Length == 0)
{
    Console.WriteLine("Args isn't set");
    return;
}
Console.WriteLine("Args:");
ExtendedConsole.WriteLineRepeat("-", 16);
for (var i = 0; i < args.Length; i++)
    Console.WriteLine($"{i}. {args[i].Replace(" ", "•")}");
ExtendedConsole.WriteLineRepeat("-", 16);

Console.WriteLine();
Console.WriteLine("Parsed:");
var parsedArgs = new Args(args);
foreach (var (name, value) in parsedArgs)
    Console.WriteLine($"{name}: {value?.Replace(" ", "•") ?? "<empty>"}");
