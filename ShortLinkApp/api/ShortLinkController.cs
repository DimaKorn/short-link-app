using ShortLinkApp.Domain.Model;
using ShortLinkApp.Domain.Repository;
using ShortLinkApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShortLinkApp.api
{
    public class ShortLinkController : ApiController
    {
        // GET: api/ShortLink
        public IEnumerable<LinkViewModel> Get()
        {
            using (var rep = new LinkRepository())
            {
                var domain = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                return rep.RetrieveAll(100).Select(l => new LinkViewModel(l,domain)) ;
            }
        }

      

        // POST: api/ShortLink
        public IHttpActionResult Post(LinkRequest request)
        {
            if(!ModelState.IsValid)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ModelState, false)));


            }
            using (var rep = new LinkRepository())
            {
                var lr = rep.CreateAndSave(request.OriginalLink);
                return Ok(new LinkViewModel(lr, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
                //return new LinkViewModel(lr,Request.RequestUri.GetLeftPart(UriPartial.Authority));
            }
        }

       

       
    }
}
