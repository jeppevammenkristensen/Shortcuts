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
        private static readonly List<ParameterDetector> _parameterDetectors; 

        static InputParameterParser()
        {
            
        }

        public static void ProcessInformation(string [] args)
        {
            
        }
    }

    public abstract class ParameterDetector
    {
        public abstract bool IsMatch(string[] args);
        public abstract Handler CreateProcessingInformation(string[] args);
    }

    public abstract class Handler
    {
        private readonly string[] _args;

        public Handler(string[] args)
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
