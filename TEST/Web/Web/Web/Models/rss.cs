namespace Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using System.Data.Linq.Mapping;

    [Table(Name = "rss")]
    public partial class rss
    {
        [Column(IsPrimaryKey = true)]
        [StringLength(200)]
        public string title { get; set; }

        [Column(IsPrimaryKey = true)]
        public DateTime date { get; set; }

        [Column]
        public string source { get; set; }

        [Column]
        public string description { get; set; }

        [Column]
        public string link { get; set; }

        [Column]
        public int? views { get; set; }
    }
}
