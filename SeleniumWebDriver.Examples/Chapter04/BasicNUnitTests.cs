using NUnit.Framework;

namespace SeleniumWebDriver.Examples.Chapter04
{
    [TestFixture]
    public class BasicNUnitTests
    {
        [Test]
        public void ShouldPassTest()
        {
            Assert.Pass();
        }
    }
}