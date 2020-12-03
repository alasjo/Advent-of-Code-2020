using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AoC2020ClassLibrary;
using AoC2020Days;
using System.IO;

namespace AoC2020NUnitTests
{
    class Day3Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPart1()
        {
            Day3 d = new Day3(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day3-Part1.txt"));

            Assert.AreEqual(7, d.Part1Long());
        }

        [Test]
        public void TestPart2()
        {
            Day3 d = new Day3(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day3-Part1.txt"));

            Assert.AreEqual(336, d.Part2Long());
        }
    }
}