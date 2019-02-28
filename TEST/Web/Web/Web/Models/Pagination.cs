using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class pageInfo
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalItems { get; set; }
        public int totalPages 
        {
            get { return (int)Math.Ceiling((decimal)totalItems / pageSize); }
        }
    }
    public class indexViewModel
    {
        public IEnumerable<rss> rssList { get; set; }
        public pageInfo pageInfo { get; set; }
    }
}