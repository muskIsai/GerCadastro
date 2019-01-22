using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GerApp.Models
{
    public class EFContext: DbContext
    {
        public EFContext() : base("GerConexao") { }

        public DbSet<CadastreObjects> CadastreObjects { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}