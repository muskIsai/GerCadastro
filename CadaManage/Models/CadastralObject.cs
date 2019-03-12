//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadaManage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CadastralObject
    {          
        [Key, Display(Name = "№:")]
        public int Id { get; set; }
        [ForeignKey(nameof(HandBookOfCOType)), Display(Name = "Тип объекта")]
        public int? fk_typeCO { get; set; }
        [Display(Name = "Кадастровый номер:")]
        public string cadastralNumber { get; set; }
        [Display(Name = "Дата внесения:")]
        public System.DateTime dateOfEntry { get; set; }
        [ForeignKey(nameof(LegalStatus)), Display(Name = "Правовой статус:")]
        public int? fk_legalStatus { get; set; }
        [Display(Name = "Адрес:")]
        public string address { get; set; }
        [Display(Name = "Кадастровый номер:")]
        public string preview { get; set; }
        public string subPreview { get; set; }
        [Display(Name = "Площадь:")]
        public double square { get; set; }
        [Display(Name = "Стоимость:")]
        public decimal cost { get; set; }        
        
        public virtual HandBookOfCOType HandBookOfCOType { get; set; }
        public virtual LegalStatus LegalStatus { get; set; }
    }
}