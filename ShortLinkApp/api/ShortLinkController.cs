using Microsoft.Practices.Unity;
using ShortLinkApp.Domain.Common;
using ShortLinkApp.Domain.Model;
using ShortLinkApp.Domain.Repository;
using ShortLinkApp.Resources;
using ShortLinkApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShortLinkApp.api
{
    public class ShortLinkController : ApiController
    {
        [Dependency]
        public ILinkRepositoryFactory RepositoryFactory { get; set; }
        [Dependency]
        public IUrlCheckingService UrlCheckingService { get; set; }
        // GET: api/ShortLink
        public IHttpActionResult Get()
        {
            using (var rep = RepositoryFactory.CreateInstance())
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
        public async Task<IHttpActionResult> Post(LinkRequest request)
        {
            if(!ModelState.IsValid)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ModelState, false)));
            }
            if(! await UrlCheckingService.IsAccessibleUrl(request.OriginalLink))
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ErrorMessages.OriginalLinkIsNotAccessible)));
            }
            using (var rep = RepositoryFactory.CreateInstance())
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
