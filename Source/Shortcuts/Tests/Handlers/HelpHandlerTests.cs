using System;
using Moq;
using NUnit.Framework;

namespace Shortcuts.Tests
{

    public class ConsoleUpwirer : IDisposable
    {
        public ConsoleUpwirer(IConsole console)
        {
            ConsoleFactory.SetConsole(console);       
        }

        public void Dispose()
        {
            ConsoleFactory.Reset();
        }
    }
    
    public class TestWithConsoleWrapper
    {
        protected Mock<IConsole> _consoleMock = new Mock<IConsole>();

        
    }

    [TestFixture]
    public class HelpHandlerTests : TestWithConsoleWrapper
    {
        [Test]
        public void Handle_CanBeCalled()
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