using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class StokConfiguration : IEntityTypeConfiguration<Stok>
    {
        public void Configure(EntityTypeBuilder<Stok> builder)
        {
            builder.Property(p => p.StakAdi).HasMaxLength(50);
            builder.Property(p => p.Birim).HasMaxLength(200);

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Kategori)
                .WithMany(s => s.Stoklar)
                .HasForeignKey(p => p.KategoriId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
