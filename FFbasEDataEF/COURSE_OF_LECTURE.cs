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
    
    public partial class COURSE_OF_LECTURE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COURSE_OF_LECTURE()
        {
            this.LECTURE = new HashSet<LECTURE>();
            this.STUDENT = new HashSet<STUDENT>();
        }
    
        public int CL_ID { get; set; }
        public string CL_THEME { get; set; }
        public Nullable<System.DateTime> CL_START { get; set; }
        public Nullable<System.DateTime> CL_END { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LECTURE> LECTURE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENT { get; set; }
    }
}
