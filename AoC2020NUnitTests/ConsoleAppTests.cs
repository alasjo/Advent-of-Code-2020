using NUnit.Framework;
using System;
using System.IO;

namespace AoC2020NUnitTests
{
    public class ConsoleAppTests
    {
        private const string Expected = "Hello AoC!";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConsoleHello()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                string[] args = { };

                AoC2020ConsoleApp.Program.Main(args);

                var result = sw.ToString().Trim();

                Assert.AreEqual(Expected, result);
            }
        }
    }
}