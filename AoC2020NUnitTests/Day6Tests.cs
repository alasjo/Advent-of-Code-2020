using System.IO;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day6Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPart1()
        {
            Day6 d = new Day6(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day6-Part1.txt"));

            Assert.AreEqual(11, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Day6 d = new Day6(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day6-Part1.txt"));

            Assert.AreEqual(6, d.Part2());
        }
    }
}
