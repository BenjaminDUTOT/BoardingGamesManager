using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardingGamesManager.Models
{
    public class BddContext : DbContext
    {
        public BddContext(DbContextOptions<BddContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<MotClef> MotClefs { get; set; }
        public DbSet<Lien> Liens { get; set; }
    }
}
