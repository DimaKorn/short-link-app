namespace ShortLinkApp.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HR.ShortLinks")]
    public partial class ShortLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShortLinkId { get; set; }

        public string OriginalLink { get; set; }

        public string TinyLink { get; set; }
    }
}
