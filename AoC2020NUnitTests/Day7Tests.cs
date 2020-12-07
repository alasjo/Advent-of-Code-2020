using System.IO;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day7Tests
    {
        private Day7 d;

        [SetUp]
        public void Setup()
        {
            d = new Day7(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day7-Part1.txt"));
        }

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(4, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(32, d.Part2());

            d = new Day7(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day7-Part2.txt"));

            Assert.AreEqual(126, d.Part2());
        }
    }
}
