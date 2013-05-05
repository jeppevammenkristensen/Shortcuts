using System;

namespace Shortcuts
{
    public class DefaultConsole : IConsole
    {
        public void WriteLine(string value, params object[] parameters)
        {
            Console.WriteLine(value, parameters);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}