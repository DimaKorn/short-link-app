using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortLinkApp.Domain;
using ShortLinkApp.Domain.Model;
using ShortLinkApp.Domain.Repository;
using ShortLinkApp.Domain.Common;
using System.Transactions;
using ShortLinkApp.Domain.Services;

namespace ShortLinkApp.Domain.Test
{
    [TestFixture]
    class ContextTest
    {

        [Test]
        public void TestMappings()
        {
            var context = new LinkDbContext();
            var items = context.LinkRecords.ToList();
            Assert.IsNotNull(items);
        }

        [Test]
        public void TestLinkRecordSaving()
        {

            RepositoryResult<LinkRecord> response=default(RepositoryResult<LinkRecord>);
            var now = DateTime.Now;
            using (var scope = new TransactionScope())
            {
                using (var rep = new LinkRepository())
                {
                    var url = string.Format("https://google.kz?id={0}", (new Random()).Next(int.MaxValue));                       
                    response = rep.CreateAndSave(url);
                }
            }
            Assert.IsTrue(response.IsSuccess);
            Assert.That(response.Data.Id, Is.GreaterThan(0));
            Assert.That(response.Data.CreateDate, Is.GreaterThan(now));
        }
        [Test]
        public void TestRetrieveByShortLink()
        {
            using (var scope = new TransactionScope())
            {
                var now = DateTime.Now;
                LinkRecord created = null;
                using (var createRep = new LinkRepository())
                {
                    var url = string.Format("http://google.kz?id={0}", (new Random()).Next(int.MaxValue));
                    var response = createRep.CreateAndSave(url);
                    created = response.Data;
                }
                LinkRecord readen = null;
                using(var readRep = new LinkRepository())
                {
                    readen = readRep.RetrieveByShortLink(created.ShortLink).Data;

                }

                Assert.That(readen.Id, Is.EqualTo(created.Id));
                Assert.That(readen.OriginalLink, Is.EqualTo(created.OriginalLink));
            }
        }

        [Test]
        public  async Task TestUrlCheckingGoodPath()
        {
            var service = new UrlCheckingService();
            var result =await service.IsAccessibleUrl("http://google.kz");
            Assert.IsTrue(result);

        }
        [Test]
        public async Task TestUrlCheckingSadNetworkPath()
        {
            var service = new UrlCheckingService();
            var result = await service.IsAccessibleUrl("http://xz.egg/dacom");
            Assert.IsFalse(result);
        }

        [Test]
        public async Task TestUrlCheckingSadFormatPath()
        {
            var service = new UrlCheckingService();
            var result = await service.IsAccessibleUrl("http:aaa");
            Assert.IsFalse(result);
        }
    }
}
