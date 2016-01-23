using ShortLinkApp.Domain.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLinkApp.Domain.Model
{
    [Table("LinkRecords")]
    public class LinkRecord
    {
        public const  int Offset = 1000;
        public  LinkRecord(string longUrl):this(){
            this.OriginalLink = longUrl;
        }
        public LinkRecord()
        {
            _lazyShortLink = new Lazy<string>(() => (this.Id+Offset).ToBase62());
        }
        private Lazy<string> _lazyShortLink;
        [Key]
        public long Id {get;set;}
        [Required]
        [StringLength(512)]
        public string OriginalLink { get; set; }
        [NotMapped]        
        public string ShortLink
        {
            get
            {
                if (this.Id == 0)
                {
                    return string.Empty;
                }
                return this._lazyShortLink.Value;
            }
        }
        public long VisitsCount { get; set;  }
        public DateTime CreateDate { get; set; }
    }
}
