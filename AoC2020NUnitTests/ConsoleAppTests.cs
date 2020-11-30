using NUnit.Framework;
using System;
using System.IO;
using AoC2020ConsoleApp;
using System.Text;

namespace AoC2020NUnitTests
{
    public class ConsoleAppTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMenu()
        {
            Menu menu = new Menu(3);
            menu.Skip(1);
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Advent of Code 2020");
            expected.AppendLine("Esc to exit");
            expected.AppendLine("");
            expected.AppendLine("");
            expected.AppendLine("[ ] Day 1");
            expected.AppendLine("[X] Day 2");
            expected.AppendLine("[ ] Day 3");
            Assert.AreEqual(expected.ToString(), menu.ToString());
        }
    }
}