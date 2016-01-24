using Microsoft.Practices.Unity;
using ShortLinkApp.Domain.Common;
using ShortLinkApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShortLinkApp.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public ILinkRepositoryFactory RepositoryFactory { get; set; }
        public ActionResult Index()
        {
          
                ViewBag.Title = "Home Page";
                return View();
          
        }

        public ActionResult ServeShortLink(string shortLink)
        {
            using (var rep = RepositoryFactory.CreateInstance())
            {
                var result = rep.RetrieveByShortLink(shortLink);
                if (!result.IsSuccess || result.Data==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var link = result.Data;
                    link.VisitsCount += 1;
                    rep.SaveAllChanges();
                    return Redirect(link.OriginalLink);
                }
            }
        }


       
    }
}
