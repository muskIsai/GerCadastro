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

    public partial class CadastralWork
    {
        [Key, Display(Name = "№:")]
        public int Id { get; set; }
        [ForeignKey(nameof(User)), Display(Name = "Инженер:")]
        public string fk_User { get; set; }
        [Display(Name = "Учет:")]
        public string accounting { get; set; }
        [Display(Name = "Описание:")]
        public string description { get; set; }
        [ForeignKey(nameof(app)), Display(Name = "Заявка:")]
        public int fk_app { get; set; }

        public virtual Application app { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
