using System.IO;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day13Tests
    {
        private Day13 d;

        [SetUp]
        public void Setup()
        {
            d = new Day13(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day13-Part1.txt"));
        }

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(295, d.Part1Long());
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(1068781, d.Part2Long());
        }
    }
}
