using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.HasKey(p => new { p.UserId, p.RoleId });
            builder.ToTable("UserRoles");
            builder.HasOne(p => p.User)
                .WithMany(s => s.UserRoles)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Role)
               .WithMany(s => s.UserRoles)
               .HasForeignKey(p => p.RoleId);

        }
    }
}
