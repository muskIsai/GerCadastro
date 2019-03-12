using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadaManage.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {        
        public string surname { get; set; }
        public string name { get; set; }
        public string patronimic { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public IEnumerable<Application> app;
        public IEnumerable<CadastralWork> cw;
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<CadastralObject> CadastralObjects { get; set; }
        public virtual DbSet<HandBookOfCOType> HandBookOfCOTypes { get; set; }
        public virtual DbSet<CadastralWork> CadastralWorks { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TypeCW> TypeCWs { get; set; }
        public virtual DbSet<LegalStatus> LegalStatus { get; set; }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}