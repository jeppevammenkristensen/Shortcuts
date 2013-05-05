using System.Collections.Generic;
using Shortcuts.Extensions;
using Shortcuts.Handlers;

namespace Shortcuts.DetectorFactories
{
    public class AddItemDetectorAndHandlerFactory : ParameterDetectorAndHandlerFactory
    {
        public override bool IsMatch(string[] args)
        {
            if (args == null || args.Length == 0)
                return false;

            var firstParameter = new List<string>() {"add", "a"};
            return firstParameter.Contains(args[0].ToLower());
        }

        protected override Handler ExecuteGetProcessingInformation(string[] args)
        {
            string name = args.GetIndexValueOrNull(1);
            string text = args.GetIndexValueOrNull(2);

            return new AddItemHandler(new AddItemOptions(name,text));
        }
    }
}