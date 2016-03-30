using NUnit.Framework;

namespace SeleniumWebDriver.Examples
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
