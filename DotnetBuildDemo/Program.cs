// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Reflection;

Console.WriteLine("Hello from dotnet 6!");

var versionInfo = GetVersionInfo();
Console.WriteLine($"assemblyVersion = {versionInfo.Item1} ");
Console.WriteLine($"fileVersion = {versionInfo.Item2} ");
Console.WriteLine($"productVersion = {versionInfo.Item3} ");

Console.ReadKey();


static Tuple<string?, string?, string?> GetVersionInfo()
{
    var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

    var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
    var productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

    return new Tuple<string?, string?, string?>(assemblyVersion, fileVersion, productVersion);
}
