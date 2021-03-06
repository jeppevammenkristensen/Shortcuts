﻿using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class ErrorHandlerTester : HandlerTester
    {
        [Test]
        public void ErrorHandler_CalledWithExceptionAndParameters_ReturnsExpectedResult()
        {
            using (StartMockedConsole())
            {
                var args = new string[] {"a", "b"};
                var exceptionText = "exceptionText";

                var errorHandler = new ErrorHandler(exceptionText,args);
                errorHandler.Handle();
                
                _console.Verify(x => x.WriteLine(It.IsAny<string>(),"a b"));
                _console.Verify(x => x.WriteLine(exceptionText));
            }
        }
    }
}