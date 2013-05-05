using System;

namespace Shortcuts
{
    public class DefaultConsole : IConsole
    {
        public void WriteLine(string value, params string[] paramters)
        {
            Console.WriteLine(value, paramters);
        }
    }
}