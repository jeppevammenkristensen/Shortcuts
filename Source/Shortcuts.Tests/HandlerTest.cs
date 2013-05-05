using Moq;

namespace Shortcuts.Tests
{
    public class HandlerTester
    {
        protected Mock<IConsole> _consoleMock = new Mock<IConsole>();

        protected ConsoleUpwirer StartMockedConsole()
        {
            return new ConsoleUpwirer(_consoleMock.Object);
        }
    }
}