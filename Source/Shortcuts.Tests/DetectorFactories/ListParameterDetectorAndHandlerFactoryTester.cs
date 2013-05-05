using NUnit.Framework;
using Shortcuts.DetectorFactories;
using Shortcuts.Handlers;

namespace Shortcuts.Tests.DetectorFactories
{
    [TestFixture]
    public class ListParameterDetectorAndHandlerFactoryTester
    {
        public readonly string[] _validArgument = new string[]{"list"};
        

        [TestCase("l")]
        [TestCase("L")]
        [TestCase("List")]
        [TestCase("LiSt")]
        public void IsMatch_ContainParameter_ReturnsMatch(string input)
        {
            var result = CreateSubject();
            string[] arguments = new string[] { input };
            Assert.That(result.IsMatch(arguments), Is.True);
        }

        private static ListParameterDetectorAndHandlerFactory CreateSubject()
        {
            var result = new ListParameterDetectorAndHandlerFactory();
            return result;
        }

        [Test]
        public void CreateProcessingInformation_IsCalled_ReturnsRelevantClass()
        {
            var subject = CreateSubject();
            var arguments = _validArgument;
            Assert.That(subject.CreateProcessingInformation(arguments), Is.TypeOf<ListHandler>());
        }
    }
}