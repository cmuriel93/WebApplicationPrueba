using Microsoft.EntityFrameworkCore;
using WebApplication_P_Empresa.Models;

namespace WebApplication_P_Empresa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
     : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Empresas>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });
        }

        public DbSet<Empresas> empresas { get; set; }
    }
}
