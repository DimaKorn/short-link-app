using ShortLinkApp.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortLinkApp.ViewModels
{
    public class LinkRequest
    {
        [Required(ErrorMessageResourceType =typeof(ErrorMessages),ErrorMessageResourceName =nameof(ErrorMessages.OriginalLinkRequired))]
        [RegularExpression(@"(\b(https?|ftp|file)://)?[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]",ErrorMessageResourceType =typeof(ErrorMessages),ErrorMessageResourceName =nameof(ErrorMessages.OriginalLinkWrongFormat))]
        public string OriginalLink { get; set; }
    }
}