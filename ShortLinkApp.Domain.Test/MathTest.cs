using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortLinkApp.Domain.Utility;
namespace ShortLinkApp.Domain.Test
{
    [TestFixture]
    class MathTest
    {
        [Test]
        public void TestToBase64Conversion()
        {
            long source = 999;
            var result = source.ToBase62();
            Assert.That(result, Is.EqualTo("G7"));
        }

        [Test]
        public void TestFromBase64Conversion()
        {
            var source = "G7";
            var result = source.FromBase62();
            Assert.That(result, Is.EqualTo(999));
        }
        [Test]
        public void TestInvalidSymbols()
        {
            var source = "!df";
            var result = source.FromBase62();
            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
