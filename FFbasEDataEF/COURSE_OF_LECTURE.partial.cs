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
    [MetadataType(typeof(COURSE_OF_LECTUREMD))]
    partial class COURSE_OF_LECTURE
    {
        public class COURSE_OF_LECTUREMD
        {
            [Required]
            [Display(Name = "Название курса")]
            public string CL_THEME { get; set; }

            [Display(Name = "Дата начала")]
            public string CL_START { get; set; }

            [Display(Name = "Дата начала")]
            public string CL_END { get; set; }
        }
    }
}
