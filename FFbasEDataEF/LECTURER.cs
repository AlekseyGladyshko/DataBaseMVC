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
    
    public partial class LECTURER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LECTURER()
        {
            this.LECTURE = new HashSet<LECTURE>();
        }
    
        public int LC_ID { get; set; }
        public int LC_C { get; set; }
        public string LC_ACTIVITY { get; set; }
    
        public virtual CLIENT CLIENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LECTURE> LECTURE { get; set; }
    }
}
