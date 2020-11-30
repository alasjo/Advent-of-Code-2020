using NUnit.Framework;
using System;
using System.IO;
using AoC2020ClassLibrary;

namespace AoC2020NUnitTests
{
    public class ClassLibraryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDay()
        {
            Day day = new Day(24);
            Assert.AreEqual("Day 24", day.ToString());
        }
    }
}