using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadaManage.Models
{
    public class PayModel
    {
        [Display(Name = "Номер карты:")]
        public string cartNumber { get; set; }
        [Display(Name = "Срок действия:"), DisplayFormat(DataFormatString = "{0:dd.MM.yy}",
               ApplyFormatInEditMode = true)]
        public System.DateTime Validity { get; set; }
        [Display(Name = "Имя карты:")]
        public string cartName { get; set; }
        [Display(Name = "Код безопасности:")]
        public string cartCod { get; set; }
    }
}