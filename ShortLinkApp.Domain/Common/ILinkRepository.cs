using ShortLinkApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Common
{
    public interface ILinkRepository:IDisposable
    {
        RepositoryResult<LinkRecord> CreateAndSave(string url);
        void SaveAllChanges();
        RepositoryResult<LinkRecord> RetrieveByShortLink(string shortLink);
        RepositoryResult<LinkRecord[]> RetrieveAll(int limit);
    }

    public interface ILinkRepositoryFactory
    {
        ILinkRepository CreateInstance();
        ILinkRepository CreateInstance(string connectionString);
    }
}
