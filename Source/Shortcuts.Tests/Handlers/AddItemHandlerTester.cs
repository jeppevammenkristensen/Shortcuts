using System;
using System.IO;
using Moq;
using NUnit.Framework;
using Shortcuts.Handlers;
using Shortcuts.Tests.Extensions;

namespace Shortcuts.Tests.Handlers
{
    [TestFixture]
    public class AddItemHandlerTester : HandlerTester
    {
        private static readonly string OptionsDefaultName = "/Sub1/Sub2/SomeName";
        private static string OptionsTextName = "Sometext";

        [TearDown]
        public void TearDown()
        {
            var directory = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory,"AdditemHandler"));
            if (directory.Exists)
                directory.Delete(true);
        }

        [Test]
        public void Handle_NameAndTextNotInput_ReceiveThem()
        {
            using (StartMockedConsole())
            {
                var handler = new AddItemHandler(new AddItemOptions(string.Empty, string.Empty),"AddItemHandler");

                _console.Setup(x => x.ReadLine()).ReturnsInOrder(
                    OptionsDefaultName,
                    OptionsTextName);

                handler.Handle();
                Assert.That(handler.Options.Name,Is.EqualTo(OptionsDefaultName));
                Assert.That(handler.Options.Text, Is.EqualTo(OptionsTextName));

                AssertFileCreatedAtCorrectLocation();

                _console.Verify(x => x.WriteLine(Resources.Resources.AddItemHandler_AddName));
                _console.Verify(x => x.WriteLine(Resources.Resources.AddItemHandler_AddText));
                _console.Verify(x => x.WriteLine(Resources.Resources.AddItemHandler_ShortcutCreated));
            }
        }

        [Test]
        public void Handle_NameAndText_PromptAndReceive()
        {
            var handler = new AddItemHandler(new AddItemOptions(OptionsDefaultName, "SomeText"), "AdditemHandler");
            handler.Handle();

            AssertFileCreatedAtCorrectLocation();
        }

        private static void AssertFileCreatedAtCorrectLocation()
        {
            var result = new FileInfo(Path.Combine(Environment.CurrentDirectory, "AdditemHandler", "Sub1", "Sub2",
                                                   "SomeName.shortc"));

            Assert.That(result.Exists, Is.True, result.FullName);
            using (var reader = new StreamReader(result.OpenRead()))
            {
                reader.ReadToEnd().Contains(OptionsTextName);
            }
        }
    }
}