using System;
using System.Collections.Generic;
using System.Linq;
using Shortcuts.DetectorFactories;
using Shortcuts.Handlers;

namespace Shortcuts
{
    public static class JobRunner
    {
        private static readonly List<ParameterDetectorAndHandlerFactory> _parameterDetectors; 

        static JobRunner()
        {
            _parameterDetectors = new List<ParameterDetectorAndHandlerFactory>();
            _parameterDetectors.Add(new HelpParameterDetectorAndHandlerFactory());
            _parameterDetectors.Add(new ListParameterDetectorAndHandlerFactory());
        }

        public static void Run(string [] args)
        {
            
            try
            {
                var parameterDetector = _parameterDetectors
                .First(x => x.IsMatch(args));

                if (parameterDetector != null) 
                    parameterDetector.CreateProcessingInformation(args).Handle();     
            }
            catch (Exception ex)
            {
                new ErrorHandler(ex.ToString(), args).Handle();
            }
            

            
        }
    }

    
}