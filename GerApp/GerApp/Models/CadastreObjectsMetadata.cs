using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerApp.Models
{
    [MetadataType(typeof(CadastreObjects))]
    public partial class CadastreObjects
    {

    }

    public class CadastreObjectsMetadata
    {
        public int CadastreObjectsID { get; set; }
        [Display(Name = "Cтоимость")]
        public decimal Price { get; set; }
        //[Required(ErrorMessage = "Объязотелно выпонить это поля", AllowEmptyStrings = false)]
        [Display(Name = "Тип кадастра")]
        public string TypeCadastre { get; set; }
        [Display(Name = "Дата доставка на учет")]
        public DateTime RegistrationDate { get; set; }
       //[Required(ErrorMessage = "Объязотелно выпонять это поля", AllowEmptyStrings = false)]
        [Display(Name = "Коментарый")]
        public string Comment { get; set; }
    }
}