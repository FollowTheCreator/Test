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
    
    public partial class TYPE_FOUNDATION
    {
        public TYPE_FOUNDATION()
        {
            this.BUILT_IN_ROOM = new HashSet<BUILT_IN_ROOM>();
            this.HOUSE = new HashSet<HOUSE>();
        }
    
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public decimal IS_ACTIVE { get; set; }
    
        public virtual ICollection<BUILT_IN_ROOM> BUILT_IN_ROOM { get; set; }
        public virtual ICollection<HOUSE> HOUSE { get; set; }
    }
}