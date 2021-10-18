using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HalloWebAPI.Model;

namespace HalloWebAPI.Data
{
    public class HalloWebAPIContext : DbContext
    {
        public HalloWebAPIContext (DbContextOptions<HalloWebAPIContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Autos;Trusted_Connection=true");
        }
        public DbSet<HalloWebAPI.Model.Auto> Auto { get; set; }
    }
}
