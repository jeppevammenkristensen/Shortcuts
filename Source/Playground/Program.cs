using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            string commandLine = "dir";
            var startInfo = new ProcessStartInfo("cmd.exe","dir")
                {
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

            var process = Process.Start(startInfo);
            using (var writer = process.StandardInput)
            {
                process.WaitForExit();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                writer.Write(commandLine);
                
                
            }

            Console.ReadLine();
        }


    }
}
