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
    
    public partial class CUSTOMER
    {
        public CUSTOMER()
        {
            this.OBJECT_CONSTRUCTION = new HashSet<OBJECT_CONSTRUCTION>();
        }
    
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public decimal IS_ACTIVE { get; set; }
    
        public virtual ICollection<OBJECT_CONSTRUCTION> OBJECT_CONSTRUCTION { get; set; }
    }
}
