using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class HelpHandlerHandlerTests : HandlerTest
    {
        [Test]
        public void Handle_CanBeCalled_ReturnsOneLineOfText()
        {
            
            using (new ConsoleUpwirer(_consoleMock.Object))
            {
                var handler = new HelpHandler(new string[] { });
                handler.Handle();    
            }

            _consoleMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once());
        }
    }
}