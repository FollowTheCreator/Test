namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;
    using System.Data.Linq.Mapping;

    [Table(Name = "rss")]
    public class rss
    {
        [Column(IsPrimaryKey = true)]
        [StringLength(200)]
        public string title { get; set; }

        [Column(IsPrimaryKey = true)]
        public DateTime date { get; set; }

        [Column]
        [StringLength(200)]
        public string source { get; set; }

        [Column]
        [StringLength(3000)]
        public string description { get; set; }

        [Column]
        [StringLength(200)]
        public string link { get; set; }

        [Column]
        public int? views { get; set; }
    }
}
