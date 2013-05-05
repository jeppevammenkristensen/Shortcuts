using Moq;

namespace Shortcuts.Tests
{
    public class HandlerTester
    {
        protected Mock<IConsole> _console = new Mock<IConsole>();

        protected ConsoleUpwirer StartMockedConsole()
        {
            return new ConsoleUpwirer(_console.Object);
        }
    }
}