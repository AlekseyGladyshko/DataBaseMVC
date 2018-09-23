using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FFbasEDataEF
{
    [MetadataType(typeof(STUDENTMD))]
    partial class STUDENT
    {
        public class STUDENTMD
        {
            [Required]
            [Display(Name = "ИД")]
            public string S_ID { get; set; }

            [Display(Name = "Клиент")]
            public string S_C { get; set; }

            [Display(Name = "Обучающий курс")]
            public string S_CL { get; set; }
        }
    }
}