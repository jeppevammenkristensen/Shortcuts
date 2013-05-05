namespace Shortcuts
{
    public static class ConsoleFactory
    {
        private static IConsole _customConsole;
        
        public static void SetConsole(IConsole console)
        {
            _customConsole = console;
        }

        public static void Reset()
        {
            _customConsole = null;
        }

        public static IConsole Console
        {
            get { return _customConsole ?? new DefaultConsole(); }
        }
    }
}