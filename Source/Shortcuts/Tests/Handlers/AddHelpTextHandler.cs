using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class AddHelpTextHandlerTests : HandlerTest
    {
         [Test]
         public void Handle_IsHandler()
         {
             //var handler = new AddTextHandler();
             //Assert.That(handler, Is.InstanceOf<Handler>());
         }

    }

    public class AddTextHandler : Handler
    {
        public AddTextHandler(string[] args) : base(args)
        {

        }

        public override void Handle()
        {
            
        }
    }
}