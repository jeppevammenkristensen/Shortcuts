using NUnit.Framework;

namespace Shortcuts.Tests
{
    [TestFixture]
    public class HelpParameterTester
    {
        [Test]
        public void IsMatch_IsHelpMatch_ReturnsTrue()
        {
            var sut = CreateSubject();
            var args = new string[0];
            Assert.That(sut.IsMatch(args), Is.True);
        }

        private static HelpParameterDetectorAndHandlerFactory CreateSubject()
        {
            return new HelpParameterDetectorAndHandlerFactory();
        }

        [Test]
        public void IsMatch_HasParameters_ReturnsFalse()
        {
            var sut = CreateSubject();
            var args = new string[] {"Something"};
            Assert.That(sut.IsMatch(args), Is.False);
        }

        [Test]
        public void CreateProcessingInformation_IsCalled_ReturnsRelevantClass()
        {
            var sut = CreateSubject();
            var args = new string[] {};
            Assert.That(sut.CreateProcessingInformation(args), Is.TypeOf<HelpHandler>());
        }

    }

    
}