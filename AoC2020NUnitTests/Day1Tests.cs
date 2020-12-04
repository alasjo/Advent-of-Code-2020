using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AoC2020ClassLibrary;
using AoC2020Days;
using System.IO;

namespace AoC2020NUnitTests
{
    class Day1Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPart1()
        {
            Day1 d = new Day1(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day1-Part1.txt"));

            Assert.AreEqual(514579, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Day1 d = new Day1(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day1-Part1.txt"));

            Assert.AreEqual(241861950, d.Part2());
        }
    }
}
