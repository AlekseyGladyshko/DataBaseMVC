using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FFbasEDataEF
{
    [MetadataType(typeof(STATUSMD))]
    partial class STATUS
    {
        public class STATUSMD
        {
            [HiddenInput(DisplayValue = false)]
            public int SG_ID { get; set; }

            [Required]
            [Display(Name = "Имя")]
            public string SG_NAME { get; set; }
        }
    }
}
