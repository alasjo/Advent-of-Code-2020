using System.IO;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day10Tests
    {
        private Day10 d;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPart1()
        {
            d = new Day10(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day10-Part1-Test1.txt"));
            Assert.AreEqual(7 * 5, d.Part1());

            d = new Day10(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day10-Part1-Test2.txt"));
            Assert.AreEqual(22 * 10, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            d = new Day10(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day10-Part1-Test1.txt"));
            Assert.AreEqual(8, d.Part2Long());

            d = new Day10(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day10-Part1-Test2.txt"));
            Assert.AreEqual(19208, d.Part2Long());
        }
    }
}
