using Microsoft.EntityFrameworkCore;
using ppedv.Personenverwaltung.Model;

namespace ppedv.Personenverwaltung.Data.EfCore
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
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Personenverwaltung_Dev;Trusted_Connection=true");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TpT
            modelBuilder.Entity<Mitarbeiter>().ToTable("Employees");
            modelBuilder.Entity<Kunde>().ToTable("Customers");
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Beruf).HasMaxLength(48).IsRequired();
        }

    }
}
