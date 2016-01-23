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
        LinkRecord CreateAndSave(string url);
        void SaveAllChanges();
        LinkRecord RetrieveByShortLink(string shortLink);
        LinkRecord[] RetrieveAll(int limit);
    }

    public interface ILinkRepositoryFactory
    {
        ILinkRepository CreateInstance();
    }
}
