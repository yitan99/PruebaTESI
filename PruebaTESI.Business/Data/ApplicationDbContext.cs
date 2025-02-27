using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaTESI.Entities;

namespace PruebaTESI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PAZIENTI> PAZIENTI { get; set; }
        public DbSet<PRELIEVI_PRENO> PRELIEVI_PRENO { get; set; }
    }
}
