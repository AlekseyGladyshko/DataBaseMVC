//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FFbasEDataEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            this.EVENT_CLIENT = new HashSet<EVENT_CLIENT>();
            this.LECTURER = new HashSet<LECTURER>();
            this.STUDENT = new HashSet<STUDENT>();
        }
    
        public int C_ID { get; set; }
        public string C_NAME { get; set; }
        public string C_EMAIL { get; set; }
        public string C_PHONE { get; set; }
        public string C_SEC_PHONE { get; set; }
        public string C_COMPANY { get; set; }
        public string C_POST { get; set; }
        public string C_EXPERIENCE { get; set; }
        public string C_INTERESTS { get; set; }
        public Nullable<int> C_SG { get; set; }
    
        public virtual STATUS STATUS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EVENT_CLIENT> EVENT_CLIENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LECTURER> LECTURER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENT { get; set; }
    }
}