using ShortLinkApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortLinkApp.Domain.Model;
using ShortLinkApp.Domain.Utility;
using System.Data.Entity.Core;
using ShortLinkApp.Domain.Resources;

namespace ShortLinkApp.Domain.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private LinkDbContext _context;
        public LinkRepository()
        {
            this._context = new LinkDbContext();
        }
        protected RepositoryResult<T> InvokeForResult<T>(Func<T> func)
        {
            try
            {
                return new RepositoryResult<T>(func());
            }
            catch(ProviderIncompatibleException ex)
            {
                return new RepositoryResult<T>(default(T), false, ErrorResources.DbProviderException+Environment.NewLine+ex.Message);

            }
            catch(EntityException ex)
            {
                return new RepositoryResult<T>(default(T), false, ErrorResources.DbGeneralException+Environment.NewLine+ex.Message);
            }
             catch(Exception ex){
                return new RepositoryResult<T>(default(T), false, ErrorResources.SystemException+Environment.NewLine+ex.Message);
            }



        }
        public void Dispose()
        {
            this._context.Dispose();
        }

        public RepositoryResult<LinkRecord[]> RetrieveAll(int limit=100)
        {
            return this.InvokeForResult(()=>
            _context.LinkRecords.OrderBy(lr => lr.Id).Take(limit).ToArray()); 
        }

        public RepositoryResult<LinkRecord> RetrieveByShortLink(string shortLink)
        {
            var id = shortLink.FromBase62() - LinkRecord.Offset;
            return this.InvokeForResult(() =>
            _context.LinkRecords.SingleOrDefault(lr => lr.Id == id));
        }

      

        public RepositoryResult<LinkRecord> CreateAndSave(string url)
        {
            return InvokeForResult(() =>
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
            });
        }

        public void SaveAllChanges()
        {
            this._context.SaveChanges();
        }
    }
}
