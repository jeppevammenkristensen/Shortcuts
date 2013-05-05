using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class ListTextHandlerTests : HandlerTest
    {
         [Test]
         public void Handle_IsHandler()
         {
             var handler = new ListTextHandler(new string[]{});
             using (this.StartMockedConsole())
             {
                 var input = new List<string>();
                 _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>()))
                             .Callback((string arg1, string[] arg2) => input.Add(arg1));
                 handler.Handle();

                 Assert.That(input, Has.Count.EqualTo(2));
                 Assert.That(input, Contains.Item("Class1"));
                 Assert.That(input, Contains.Item("Nested"));
                
             }
                     
         }

    }
}