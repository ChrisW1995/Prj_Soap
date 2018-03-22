using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Prj_Soap.Models;

namespace Prj_Soap.Models
{
    // 您可將更多屬性新增至 ApplicationUser 類別，藉此為使用者新增設定檔資料，如需深入了解，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=317594。
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Soap> Soaps { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Carts> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Areas>()
                .HasRequired(c => c.Counties)
                .WithMany(a => a.Areas)
                .HasForeignKey(f => f.CountyId);

            modelBuilder.Entity<Carts>()
                .HasRequired(c => c.Customer)
                .WithMany(a => a.Carts)
                .HasForeignKey(f => f.CustomerId);

            modelBuilder.Entity<Carts>()
              .HasRequired(c => c.Soap)
              .WithMany(a => a.Carts)
              .HasForeignKey(f => f.SoapId);

            modelBuilder.Entity<Messages>()
                .HasRequired(c => c.Customer)
                .WithMany(a => a.Messages)
                .HasForeignKey(f => f.C_Id);

            modelBuilder.Entity<Messages>()
                .HasRequired(c => c.Soap)
                .WithMany(a => a.Messages)
                .HasForeignKey(f => f.P_Id);


            //modelBuilder.Entity<Customers>()
            //    .HasRequired(c => c.Counties)
            //    .WithMany(c => c.Customers)
            //    .HasForeignKey(f => f.CountyId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Customers>()
            //    .HasRequired(a => a.Areas)
            //    .WithMany(c => c.Customers)
            //    .HasForeignKey(f => f.AreaId)
            //    .WillCascadeOnDelete(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}