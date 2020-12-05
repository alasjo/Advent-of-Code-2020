using System.IO;
using NUnit.Framework;
using AoC2020Days;

namespace AoC2020NUnitTests
{
    class Day5Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPart1()
        {
            Day5 d = new Day5(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Input", "Day5-Part1.txt"));

            Assert.AreEqual(820, d.Part1());
        }
    }
}
