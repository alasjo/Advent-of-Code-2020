using NUnit.Framework;
using System.Collections.Generic;
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

        [Test]
        public void TestFileParser()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "TextFile.txt");

            FileParser parser = new FileParser(path);

            Assert.AreEqual(26, parser.Lines.Count);
            Assert.AreEqual("C", parser.Lines[2]);
        }
    }
}