using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tree.Models
{
    public class subdata1 // класс для доп инфы для субъектов
    {
        public Nullable<System.DateTime> DATE_RECEIPT { get; set; }
        public Nullable<System.DateTime> DATE_EXPIRY { get; set; }
        public string FULL_NAME { get; set; }
        public string TEXT_COMMENT { get; set; }
        public string ALL_TYPE_SOUR_FIN { get; set; }
        public Nullable<System.DateTime> DATE_RECEIPT1 { get; set; }
        public Nullable<System.DateTime> DATE_EXPIRY1 { get; set; }
        public string COMMENT { get; set; }
        public decimal ID { get; set; }
    }
}