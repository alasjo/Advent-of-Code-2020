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

        [Test]
        public void TestFileParser()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "TextFile.txt");

            FileParser parser = new FileParser(path);

            Assert.AreEqual(26, parser.Lines.Count);
            Assert.AreEqual("C", parser.Lines[2]);
        }

        [Test]
        public void TestPassport()
        {
            string input = "eid:bla \n iyr:123 hgt:abS cid: 12 hcl:#112233";

            Passport pass = Passport.FromString(input);

            Assert.AreEqual("byr: iyr:123 eyr: hgt:ab hcl:#112233 ecl: pid: cid:", pass.ToString());
            Assert.False(pass.IsValid);

            pass = Passport.FromString("byr:1920   iyr:2012 eyr:2022 hgt:170cm\nhcl:#556677 ecl:gry pid:123456789");

            Assert.True(pass.IsValid);
        }

        [Test]
        public void TestBoardingPass()
        {
            /**
             * : row 70, column 7, seat ID 567.
             * : row 14, column 7, seat ID 119.
             * : row 102, column 4, seat ID 820.
             */
        }

        [Test]
        public void TestTree()
        {
            Tree<int> tree = new Tree<int>(0);

            for (int i = 1; i < 5; i++)
            {
                tree.AddChild(i);
                tree.ChildAt(i - 1).AddChild(i + 4);
            }

            Action<int> visitor;
            int count = 0;
            int sumn = 0;

            visitor = delegate (int c)
            {
                count++;
                sumn += c;
            };

            Tree<int>.Traverse(tree, visitor);

            Assert.AreEqual(9, count);
            Assert.AreEqual(36, sumn);
        }
    }
}