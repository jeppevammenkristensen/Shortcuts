using System;
using System.IO;
using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class AddItemHandlerTester : HandlerTester
    {
        [TearDown]
        public void TearDown()
        {
            var directory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory,"AdditemHandler"));
            if (directory.Exists)
                directory.Delete(true);
        }

        [Test]
        public void Handle_NameAndText_PromptAndReceive()
        {
            using (StartMockedConsole())
            {
                _consoleMock.Setup(x => x.WriteLine(It.IsAny<string>())); //.Callback((string arg1, string arg2)
                    // => )

                var handler = new AddItemHandler(new AddItemOptions("/Sub1/Sub2/SomeName", "SomeText"), "AdditemHandler");
                handler.Handle();

                Assert.That(new FileInfo(Path.Combine(Environment.CurrentDirectory,"AdditemHandler","Sub1","Sub2","SomeName.shortc")).Exists, Is.True);

                
            }
        }
    }
}