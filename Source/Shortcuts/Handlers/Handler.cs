namespace Shortcuts.Handlers
{
    public abstract class Handler
    {
        protected IConsole _Console
        {
            get { return ConsoleFactory.Console; }
        }

       
        protected readonly string[] Args;

        protected Handler() : this(new string[]{})
        {
            
        }

        // considering if it's necesarry to have a dependency on the args. 
        protected Handler(string[] args)
        {
            Args = args;
        }

        public abstract void Handle();
    }
}