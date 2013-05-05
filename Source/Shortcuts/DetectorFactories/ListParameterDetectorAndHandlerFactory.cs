using System.Collections.Generic;
using Shortcuts.Handlers;

namespace Shortcuts.DetectorFactories
{
    public class ListParameterDetectorAndHandlerFactory : ParameterDetectorAndHandlerFactory
    {
        public override bool IsMatch(string[] args)
        {
            return new List<string>(){"l", "list"}.Contains(args[0].ToLower());
        }

        protected override Handler ExecuteGetProcessingInformation(string[] args)
        {
            return new ListHandler();
        }
    }
}