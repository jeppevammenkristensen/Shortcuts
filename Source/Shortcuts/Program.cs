using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortcuts
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class InputParameterParser
    {
        private static readonly List<ParameterDetectorAndHandlerFactory> _parameterDetectors; 

        static InputParameterParser()
        {
            _parameterDetectors = new List<ParameterDetectorAndHandlerFactory>();
            _parameterDetectors.Add(new HelpParameterDetectorAndHandlerFactory());
        }

        public static void ProcessInformation(string [] args)
        {
            
        }
    }

    public class HelpParameterDetectorAndHandlerFactory : ParameterDetectorAndHandlerFactory
    {
        public override bool IsMatch(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return true;
            }

            return false;
        }

        protected override Handler ExecuteGetProcessingInformation(string[] args)
        {
            return new HelpHandler(args);
        }
    }

    public abstract class ParameterDetectorAndHandlerFactory
    {
        public abstract bool IsMatch(string[] args);
        public Handler CreateProcessingInformation(string[] args)
        {
            if (!IsMatch(args))
                throw new InvalidOperationException("The args passed in is not a match. Remember to call the IsMatch before passing them in");
            
            return ExecuteGetProcessingInformation(args);
        }

        protected abstract Handler ExecuteGetProcessingInformation(string[] args);

    }

    public class HelpHandler : Handler
    {
        public HelpHandler(string[] args) : base(args)
        {

        }

        public override void Handle()
        {
            throw new NotImplementedException();
        }
    }


    public abstract class Handler
    {
        private readonly string[] _args;

        protected Handler(string[] args)
        {
            _args = args;
        }

        public abstract void Handle();
    }

    public enum OperationType
    {
        Help,
        ListShortcuts
    }
}
