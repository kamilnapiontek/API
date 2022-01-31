using Kolokwium.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Api {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring (optionsBuilder);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            
        }

        public DbSet<Product> Products { get; set; }
    }
}