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
        public IHttpActionResult Get()
        {
            using (var rep = new LinkRepository())
            {
                var response = rep.RetrieveAll(100);
                if (response.IsSuccess)
                {
                    var domain = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                    return Ok(response.Data.Select(l => new LinkViewModel(l, domain)));
                }
                else
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(response.Message)));

                }
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
                var response = rep.CreateAndSave(request.OriginalLink);
                return
                    response.IsSuccess ?
                    Ok(new LinkViewModel(response.Data, Request.RequestUri.GetLeftPart(UriPartial.Authority))) as IHttpActionResult
                    : ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError( response.Message)));

                //return new LinkViewModel(lr,Request.RequestUri.GetLeftPart(UriPartial.Authority));
            }
        }

       

       
    }
}
