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
    [MetadataType(typeof(LECTUREMD))]
    partial class LECTURE
    {
        public class LECTUREMD
        {
            [Required]
            [Display(Name = "Тема")]
            public string L_TOPIC { get; set; }

            [Display(Name = "Дата")]
            public string L_DATE { get; set; }

            [Required]
            [Display(Name = "Лектор")]
            public int L_LC { get; set; }

            [Display(Name = "Обучающий курс")]
            public int L_CL { get; set; }
        }
    }
}



