namespace Shortcuts.Handlers
{
    public abstract class Handler
    {
        protected IConsole _Console
        {
            get { return ConsoleFactory.Console; }
        }

        protected readonly string[] Args;

        protected Handler(string[] args)
        {
            Args = args;
        }

        public abstract void Handle();
    }
}