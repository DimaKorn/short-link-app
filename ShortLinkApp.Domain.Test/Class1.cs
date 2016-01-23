using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void Test2()
        {
            Assert.That(2 + 2, Is.EqualTo(10));
        }
    }
}
