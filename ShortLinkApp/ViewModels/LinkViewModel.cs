using ShortLinkApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortLinkApp.ViewModels
{
    public class LinkViewModel
    {
        public LinkViewModel()
        {

        }
        public LinkViewModel(LinkRecord lr,string domainAuthority)
        {
            
           
            this.OriginalLink = lr.OriginalLink;
            this.ShortLink =domainAuthority+"/"+ lr.ShortLink;
            this.CreationDate = lr.CreateDate.ToString();
            this.VisitsCount = lr.VisitsCount;
        }

        public string OriginalLink { get; set; }
        public string ShortLink { get; set;}
        public long VisitsCount { get; set; }
        public string CreationDate { get; set; }
    }
}