using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTESI.Entities;

namespace PruebaTESI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring
                 (DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer(@"data source=201.149.25.122,5623;initial catalog=Winlab;User Id=tesi;Password=Tesitesi2022;TrustServerCertificate=True;");
            base.OnConfiguring(OptionsBuilder);
        }
        public DbSet<PAZIENTI> PAZIENTI { get; set; }
        public DbSet<PRELIEVI_PRENO> PRELIEVI_PRENO { get; set; }
    }
}
