using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day9Tests
    {
        private Day9 d;

        [SetUp]
        public void Setup()
        {
            d = new Day9(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day9-Part1.txt"), 5);
        }

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(127, d.Part1Long());
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(62, d.Part2Long());
        }
    }
}
