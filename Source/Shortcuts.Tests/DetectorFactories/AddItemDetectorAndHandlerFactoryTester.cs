using NUnit.Framework;
using Shortcuts.DetectorFactories;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.DetectorFactories
{
    [TestFixture]
    public class AddItemDetectorAndHandlerFactoryTester
    {
         [Test]
         public void IsMatch_WithValidArg_ReturnsTrue()
         {
             var result = CreateSubject();
             var args = new string[] {"Add", "Somename"};

             Assert.That(result.IsMatch(args), Is.True);
         }

        [Test]
         public void CreateProcessingInformation_IsValid_ReturnsObjectWithRelevantOptions()
        {
            var subject = CreateSubject();
            var args = new string[] { "Add", "Somename", "Dette er noget tekst"};
            
            var result = subject.CreateProcessingInformation(args);

            Assert.That(result, Is.TypeOf<AddItemHandler>());
            var castResult = result as AddItemHandler;
            Assert.That(castResult.Options.Name, Is.EqualTo("Somename"));
            Assert.That(castResult.Options.Text, Is.EqualTo("Dette er noget tekst"));

        }

        private static AddItemDetectorAndHandlerFactory CreateSubject()
        {
            var result = new AddItemDetectorAndHandlerFactory();
            return result;
        }
    }
}