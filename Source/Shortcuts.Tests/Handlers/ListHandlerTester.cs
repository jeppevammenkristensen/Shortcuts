using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class ListHandlerTester : HandlerTester
    {
         [TearDown]
         public void TearDown()
         {
             var info = new DirectoryInfo("NonExisting");
             if (info.Exists)
                 info.Delete(true);
         }

         [Test]
         public void Handle_ExistingFolder_ListItems()
         {
             var handler = new ListHandler();
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

        [Test]
        public void Handle_FolderDoesNotExist_CreatesFolder()
        {
            var handler = new ListHandler("NonExisting");
            
            Assert.DoesNotThrow(() => handler.Handle());
            Assert.That(new DirectoryInfo("NonExisting").Exists, Is.True);
        }
    }
}