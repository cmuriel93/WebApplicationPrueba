using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationPrueba.Models;

namespace WebApplicationPrueba.Data
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
                .Entity<Empleados>(
                    eb =>
                    {
                        eb.HasNoKey();
                    });
        }

        public DbSet<Empleados> empleados { get; set; }
    }
}
