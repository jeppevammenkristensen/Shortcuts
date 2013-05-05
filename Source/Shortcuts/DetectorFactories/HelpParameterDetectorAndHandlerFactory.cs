using Shortcuts.Handlers;

namespace Shortcuts.DetectorFactories
{
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
}