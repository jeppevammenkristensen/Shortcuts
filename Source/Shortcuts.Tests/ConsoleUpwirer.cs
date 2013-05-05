using System;

namespace Shortcuts.Tests
{
    public class ConsoleUpwirer : IDisposable
    {
        public ConsoleUpwirer(IConsole console)
        {
            ConsoleFactory.SetConsole(console);       
        }

        public void Dispose()
        {
            ConsoleFactory.Reset();
        }
    }
}