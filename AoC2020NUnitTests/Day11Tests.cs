using System.IO;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day11Tests
    {
        private Day11 d;

        [SetUp]
        public void Setup()
        {
            d = new Day11(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day11-Part1.txt"));
        }

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(37, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(26, d.Part2());
        }
    }
}
