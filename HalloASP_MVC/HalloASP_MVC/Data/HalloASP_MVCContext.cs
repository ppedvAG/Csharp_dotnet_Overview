using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HalloASP_MVC.Models;

namespace HalloASP_MVC.Data
{
    public class HalloASP_MVCContext : DbContext
    {
        public HalloASP_MVCContext (DbContextOptions<HalloASP_MVCContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Autos;Trusted_Connection=true");

        }

        public DbSet<HalloASP_MVC.Models.Auto> Auto { get; set; }
    }
}
