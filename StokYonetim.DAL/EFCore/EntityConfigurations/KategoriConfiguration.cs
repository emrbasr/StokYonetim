using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(p => p.KategoriAdi).HasMaxLength(50);
            builder.Property(p => p.Aciklama).HasMaxLength(50);

            builder.HasMany(p => p.Stoklar)
                .WithOne(s => s.Kategori)
                .HasForeignKey(p => p.KategoriId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
