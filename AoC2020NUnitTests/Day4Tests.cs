using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AoC2020ClassLibrary;
using AoC2020Days;
using NUnit.Framework;

namespace AoC2020NUnitTests
{
    class Day4Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPart1()
        {
            Day4 d = new Day4(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day4-Part1.txt"));

            Assert.AreEqual(2, d.Part1());
        }

        [Test]
        public void TestPart2()
        {
            Day4 d = new Day4(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day4-Part2.txt"));

            Assert.AreEqual(4, d.Part2());
        }
    }
}
