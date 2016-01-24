using ShortLinkApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Services
{
    public class UrlCheckingService : IUrlCheckingService
    {
        public async Task<bool> IsAccessibleUrl(string url)
        {
            try
            {
           
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch(Exception ex) when (ex is HttpRequestException || ex is WebException || ex is InvalidOperationException) {
                
                    return false;
                }
        }
    }
}

