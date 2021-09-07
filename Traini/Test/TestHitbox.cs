using NUnit.Framework;
using NUnit.Framework.Constraints;
using Traini.Model.Util;

namespace Test
{
    public class TestHitbox
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCollidingWithPoint()
        {
            var coord = new Coord(10, 10);
            Assert.Pass();
        }
    }
}