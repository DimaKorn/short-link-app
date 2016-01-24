using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Common
{
    public interface IUrlCheckingService
    {
        Task<bool> IsAccessibleUrl(string url);
    }
}
