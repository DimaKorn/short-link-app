using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortLinkApp.Domain;
using ShortLinkApp.Domain.Model;
using ShortLinkApp.Domain.Repository;

namespace ShortLinkApp.Domain.Test
{
    [TestFixture]
    class ContextTest
    {

        [Test]
        public void TestContext()
        {
            var context = new LinkDbContext();
            var items = context.LinkRecords.ToList();
            Assert.IsNotNull(items);
        }
        [Test]
        public void Saving()
        {
            var lr = new LinkRecord("https://google.kz");
            using (var rep = new LinkRepository())
            {
                rep.CreateAndSave(lr);

            }
            Assert.That(lr.Id, Is.GreaterThan(0));

        }
        [Test]
        public void Getting()
        {
            using (var rep = new LinkRepository())
            {
                var all = rep.RetrieveAll(500);
            }
        }
    }
}
