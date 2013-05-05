using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class HelpHandlerHandlerTester : HandlerTester
    {
        [Test]
        public void Handle_CanBeCalled_ReturnsOneLineOfText()
        {
            
            using (new ConsoleUpwirer(_console.Object))
            {
                var handler = new HelpHandler(new string[] { });
                handler.Handle();    
            }

            _console.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once());
        }
    }
}