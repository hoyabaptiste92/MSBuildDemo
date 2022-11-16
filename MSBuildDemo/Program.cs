using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSBuildDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from .NET 4.7.2");
            var versionInfo = GetVersionInfo();

            Console.WriteLine($"assemblyVersion = {versionInfo.Item1} ");
            Console.WriteLine($"fileVersion = {versionInfo.Item2} ");
            Console.WriteLine($"productVersion = {versionInfo.Item3} ");

            Console.ReadKey();
        }

        static Tuple<string, string, string> GetVersionInfo() {
            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            
            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            string productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

            return new Tuple<string, string, string>(assemblyVersion, fileVersion, productVersion);
        }
    }
}
