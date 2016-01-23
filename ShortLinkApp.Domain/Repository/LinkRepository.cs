using ShortLinkApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortLinkApp.Domain.Model;
using ShortLinkApp.Domain.Utility;

namespace ShortLinkApp.Domain.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private LinkDbContext _context;
        public LinkRepository()
        {
            this._context = new LinkDbContext();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        public LinkRecord[] RetrieveAll(int limit)
        {
            return _context.LinkRecords.OrderBy(lr => lr.Id).Take(limit).ToArray(); 
        }

        public LinkRecord RetrieveByShortLink(string shortLink)
        {
            var id = shortLink.FromBase62() - LinkRecord.Offset;
            return _context.LinkRecords.SingleOrDefault(lr => lr.Id == id);
        }

      

        public LinkRecord CreateAndSave(string url)
        {
            var exisiting = _context.LinkRecords.FirstOrDefault(lr => lr.OriginalLink == url);
            if (exisiting != null)
                return exisiting;
            var record = new LinkRecord(url)
            {
                CreateDate = DateTime.Now
            };
            _context.LinkRecords.Add(record);
            _context.SaveChanges();
            return record;
        }

        public void SaveAllChanges()
        {
            this._context.SaveChanges();
        }
    }
}
