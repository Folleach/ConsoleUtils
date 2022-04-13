# ConsoleUtils

For help & simplify to your code <3

## Install
Add to your **csproj**
```csproj
<PackageReference Include="Folleach.ConsoleUtils" Version="1.0.0" />
```
Or download from [NuGet](https://www.nuget.org/packages/Folleach.ConsoleUtils/)

## Examples

### Setup console
```cs
ExtendedConsole.SetupUTF8(); // For use UTF-8 by default, instead of local culture
```


### Args
```cs
var parsedArgs = new Args(args);
```
For console command
`programm.exe -a -b with_value --full-name "The name" -xyz 10`  
<table>
  <td>

Args will be
| Key       | Value       |
| :-------- | :---------- |
| a         |             |
| b         | with_value  |
| full-name | The name    |
| x         |             |
| y         |             |
| z         | 10          |


  </td>
  <td width="123456789px">

And it can be used as
```cs
Console.WriteLine(parsedArgs.Contains("a"));  // true
Console.WriteLine(parsedArgs.GetString("a")); // null

Console.WriteLine(parsedArgs.GetString("full-name")); // The name

if (parsedArgs.TryGetString("b", out var value)) // If contains "b"
    Console.WriteLine(value);                    // write the value

foreach (var (key, value) in parsedArgs)     // Access to all args
    Console.WriteLine($"{key} is {value}");  // and write them

return "Be careful ;)";
```

  </td>
</table>

