//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tree
{
    using System;
    using System.Collections.Generic;
    
    public partial class OBJECT_CONSTRUCTION
    {
        public OBJECT_CONSTRUCTION()
        {
            this.SUB_OBJECT = new HashSet<SUB_OBJECT>();
        }
    
        public decimal ID { get; set; }
        public decimal MICRODISTRICT_ID { get; set; }
        public Nullable<decimal> TYPE_OBJECT_CONSTRUCTION_ID { get; set; }
        public string NAME { get; set; }
        public string FULL_NAME { get; set; }
        public decimal CUSTOMER_ID { get; set; }
        public string CONTRACT_NUMBER { get; set; }
        public Nullable<System.DateTime> CONTRACT_DATE { get; set; }
        public string CONTRACT_COMMENT { get; set; }
        public Nullable<decimal> GEN_MANAGEMENT_ID { get; set; }
        public decimal IS_ACTIVE { get; set; }
        public string SCHEME_FILE_NAME { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual ICollection<SUB_OBJECT> SUB_OBJECT { get; set; }
    }
}