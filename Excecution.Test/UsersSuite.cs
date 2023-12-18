using Execution.Suite.Attributes;
using Execution.Suite.Impl;
using NUnit.Framework;

namespace Excecution.Test
{
    [Suite("Users")]
    [Area("UsersArea")]
    public class UsersSuites
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TfsId(120)]
        public void UserTest()
        {
            var service = new TestBuilderService(8);
            var testData = service.GetTestInfoFromStack();
            testData.ToString();
            Assert.Pass();
        }
    }
}