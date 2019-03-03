using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tree.Models
{
    public class objects_result1  // Класс для объектов
    {
        public decimal ID { get; set; }
        public string FULL_NAME { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CONTRACT_NUMBER { get; set; }
        public Nullable<System.DateTime> CONTRACT_DATE { get; set; }
        public string COMMENT { get; set; }
        public string MANAGEMENT_NAME { get; set; }

    }
}