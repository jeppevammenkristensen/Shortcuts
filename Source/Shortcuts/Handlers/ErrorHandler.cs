using System;

namespace Shortcuts.Handlers
{
    public class ErrorHandler : Handler
    {
        private readonly string _exceptionText;

        public ErrorHandler(string exceptionText, string[] args) : base(args)
        {
            _exceptionText = exceptionText;
        }

        public override void Handle()
        {
            _Console.WriteLine("An error occured for call with parameters {0}", string.Join(" ", Args));
            _Console.WriteLine(_exceptionText);
        }
    }
}