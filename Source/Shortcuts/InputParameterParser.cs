using System.Collections.Generic;

namespace Shortcuts
{
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
}