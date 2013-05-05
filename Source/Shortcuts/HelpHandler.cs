using System;

namespace Shortcuts
{
    public class HelpHandler : Handler
    {
        public HelpHandler(string[] args) : base(args)
        {

        }

        public override void Handle()
        {
            _Console.WriteLine("Here is the help information needed");
        }
    }
}