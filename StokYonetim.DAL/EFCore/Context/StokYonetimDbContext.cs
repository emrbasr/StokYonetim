using Microsoft.EntityFrameworkCore;
using StokYonetim.Entites;
using System.Reflection;

namespace StokYonetim.DAL.EFCore.Context
{
    public class StokYonetimDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=11.0.17.100;Port=5432;Database=StockYonetim;User Id=postgres;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
