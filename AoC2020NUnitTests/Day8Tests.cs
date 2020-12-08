using System.IO;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day8Tests
    {
        private Day8 d;

        [SetUp]
        public void Setup()
        {
            d = new Day8(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day8-Part1.txt"));
        }

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(5, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(8, d.Part2());
        }
    }
}
