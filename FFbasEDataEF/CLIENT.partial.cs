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
    [MetadataType(typeof(CLIENTMD))]
    partial class CLIENT
    {
        public SelectList StatusList { get; set; }

        public class CLIENTMD
        {
            [Required]
            [Display(Name = "Имя/фамилия")]
            public string C_NAME { get; set; }

            [Display(Name = "E-mail")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный e-mail")]
            public string C_EMAIL { get; set; }

            [Display(Name = "Телефон")]
            [RegularExpression(@"^(?:\d{8}|00\d{10}|\+\d{2}\d{8})$", ErrorMessage = "Некорректный телефон")]
            public string C_PHONE { get; set; }

            [Display(Name = "Телефон(2)")]
            [RegularExpression(@"^(?:\d{8}|00\d{10}|\+\d{2}\d{8})$", ErrorMessage = "Некорректный телефон")]
            public string C_SEC_PHONE { get; set; }

            [Display(Name = "Компания")]
            public string C_COMPANY { get; set; }

            [Display(Name = "Должность")]
            public string C_POST { get; set; }

            [Display(Name = "Опыт работы")]
            public string C_EXPERIENCE { get; set; }

            [Display(Name = "Интересы")]
            public string C_INTERESTS { get; set; }

            [Display(Name = "Статус")]
            public int C_SG { get; set; }
        }
    }
}
