using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AoC2020ClassLibrary;
using AoC2020Days;
using System.IO;

namespace AoC2020NUnitTests
{
    class Day2Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPart1()
        {
            Day2 d = new Day2(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day2-Part1.txt"));

            Assert.AreEqual(2, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Day2 d = new Day2(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day2-Part1.txt"));

            Assert.AreEqual(2, d.Part2());
        }
    }
}
