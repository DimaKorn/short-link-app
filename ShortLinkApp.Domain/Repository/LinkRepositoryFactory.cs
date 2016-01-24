using ShortLinkApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Repository
{
    public class LinkRepositoryFactory : ILinkRepositoryFactory
    {
        public ILinkRepository CreateInstance()
        {
            return new LinkRepository();
        }

        public ILinkRepository CreateInstance(string connectionString)
        {
            return new LinkRepository(connectionString);
        }
    }
}
