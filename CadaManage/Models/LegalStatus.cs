using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadaManage.Models
{
    public class LegalStatus
    {
        [Key]
        public int Id { get; set; }
        public string lsName { get; set; }

        [InverseProperty(nameof(CadastralObject.LegalStatus))]
        public virtual ICollection<CadastralObject> CadastralObjects { get; set; } = new HashSet<CadastralObject>();
    }
}