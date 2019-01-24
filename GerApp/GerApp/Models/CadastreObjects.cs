using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerApp.Models
{
    public partial class CadastreObjects
    {
        [Display(Name = "ID")]
        public int CadastreObjectsID { get; set; }
        [Display(Name = "Cтоимость")]
        public decimal Price { get; set; }
        [Display(Name = "Тип кадастра")]
        public string TypeCadastre { get; set; }
        [Display(Name = "Дата доставка на учет")]
        public DateTime RegistrationDate { get; set; }
        [Display(Name = "Коментарый")]
        public string Comment { get; set; }
    }
}