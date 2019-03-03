using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tree.Models
{
    public class subdata1_house // класс для доп инфы для субъектов (для домов)
    {
        public Nullable<System.DateTime> BEGINNING_TECHNICAL_BREAK { get; set; }
        public Nullable<System.DateTime> TERMINATION_TECHNICAL_BREAK { get; set; }
        public Nullable<decimal> MAX_COUNT_FLOORS { get; set; }
        public Nullable<decimal> COUNT_APARTMENTS { get; set; }
        public Nullable<decimal> TOTAL_AREA { get; set; }
        public Nullable<System.DateTime> SETTLING_DATE { get; set; }
        public string NAME { get; set; }
        public string ALL_SERIES { get; set; }
        public decimal ID { get; set; }
    }
}