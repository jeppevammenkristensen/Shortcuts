using System;
using Shortcuts.Handlers;

namespace Shortcuts.DetectorFactories
{
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
}