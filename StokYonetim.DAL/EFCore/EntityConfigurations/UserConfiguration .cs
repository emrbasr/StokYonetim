using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(p => p.UserName).HasMaxLength(50);
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.RefreshToken).HasMaxLength(50);

            builder.HasMany(p => p.UserRoles)
                .WithOne(s => s.User)
                .HasForeignKey(p => p.UserId);

        }

    }
}
