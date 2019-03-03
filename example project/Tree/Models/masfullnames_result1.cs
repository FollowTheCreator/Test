using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tree.Models
{
    public class masfullnames_result1 // Класс для субъектов
    {
        public string NAME{ get; set; }
        public string CODE { get; set; }
        public string TYPE_SUB_OBJECT_NAME { get; set; }
        public decimal ID { get; set; }
        public decimal ALL_SCH_WORK_IS_COMPLETE { get; set; }
        public Nullable<decimal> CONSTRUCTION_PERIOD { get; set; }
        public string PERM_IDKNS_NUMBER { get; set; }
        public Nullable<System.DateTime> PERM_BUILDING_SITE_DATE_RECEIPT { get; set; }
        public Nullable<System.DateTime> PERM_BUILDING_SITE_EXPIRY_DATE { get; set; }
        public Nullable<System.DateTime> COMMISSIONIN_DATE { get; set; }
        public string CAST { get; set; }
    }
}