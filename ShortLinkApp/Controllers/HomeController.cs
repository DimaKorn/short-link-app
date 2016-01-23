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
        public ActionResult Index(string shortLink)
        {
            if (string.IsNullOrEmpty(shortLink))
            {
                ViewBag.Title = "Home Page";

                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult ServeShortLink(string shortLink)
        {
            using (var rep = new LinkRepository())
            {
                var link = rep.RetrieveByShortLink(shortLink);
                if (link == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    link.VisitsCount += 1;
                    rep.SaveAllChanges();
                    return Redirect(link.OriginalLink);
                }
            }
        }


       
    }
}
