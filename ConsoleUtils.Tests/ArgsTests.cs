using NUnit.Framework;

namespace Folleach.ConsoleUtils.Tests
{
    [TestFixture]
    public class ArgsTests
    {
        [TestCase("n", true, "-n")]
        [TestCase("n", false, "-x")]
        [TestCase("n", true, "-nn")]
        [TestCase("n", false, "--nn")]
        [TestCase("n", true, "-nx")]
        [TestCase("n", true, "-xn")]
        [TestCase("n", true, "-x", "-n")]
        [TestCase("n", true, "-x", "haha", "-n")]
        [TestCase("n", true, "-n   ")]
        [TestCase("n", true, "   -n")]
        [TestCase("n", false)]
        [TestCase("n", false, "")]
        [TestCase("n", false, "    ")]
        [TestCase(" ", false, "- n")]
        [TestCase("mytype", true, "--mytype")]
        [TestCase("mytype", true, "--mytype", "with value")]
        public void ContainsTests(string value, bool contains, params string[] rawArgs)
        {
            var args = new Args(rawArgs);
            Assert.AreEqual(contains, args.Contains(value));
        }

        [TestCase("n", "hello", "-n", "hello")]
        [TestCase("n", null, "hello", "-n")]
        [TestCase("n", null, "-n")]
        [TestCase("n", null)]
        [TestCase("param", "value", "--param", "value")]
        [TestCase("param", null, "-param", "value")]
        [TestCase("m", "value", "-param", "value")]
        [TestCase("a", null, "-param", "value")]
        [TestCase("n", "value", "-n", "-n", "value")]
        [TestCase("n", "value", "-n", "value", "-n")]
        public void GetStringTests(string key, string expected, params string[] rawArgs)
        {
            var args = new Args(rawArgs);
            Assert.AreEqual(expected, args.GetString(key));
        }
    }
}
