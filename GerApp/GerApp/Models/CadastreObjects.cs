using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerApp.Models
{
    public partial class CadastreObjects
    {
        public int CadastreObjectsID { get; set; }
        public decimal Price { get; set; }
        public string TypeCadastre { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Comment { get; set; }
    }
}