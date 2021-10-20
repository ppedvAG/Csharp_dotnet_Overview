using EfCoreCodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCodeFirst.Data
{
    public class EfContext : DbContext
    {
        public DbSet<Abteilung> Abteilungen { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Kunde> Kunden { get; set; }

        public EfContext()
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCoreCodeFirst;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TpT
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            //modelBuilder.Entity<Kunde>().ToTable("Customer");
            modelBuilder.Entity<Kunde>().ToTable("Kunde");
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Beruf).HasMaxLength(48).IsRequired();
        }

    }
}
