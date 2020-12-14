using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day12Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPart1()
        {
            Day12 d = new Day12(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day12-Part1.txt"));

            Assert.AreEqual(25, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Day12 d = new Day12(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day12-Part1.txt"));

            Assert.AreEqual(286, d.Part2());
        }
    }
}
