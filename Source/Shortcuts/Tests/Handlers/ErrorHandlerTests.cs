using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class ErrorHandlerTests : HandlerTest
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
                
                _consoleMock.Verify(x => x.WriteLine(It.IsAny<string>(),"a b"));
                _consoleMock.Verify(x => x.WriteLine(exceptionText));
            }
        }
    }
}