using EasyDDD.Domain.SystemVersions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyDDD.Infrastructure.Data.DbContexts.BoundedContext.Mappings
{
    public sealed class SystemVersionMap : IEntityTypeConfiguration<SystemVersion>
    {
        public void Configure(EntityTypeBuilder<SystemVersion> builder)
        {
            builder.ToTable(nameof(Version))
                   .HasKey(p => p.Id)
                   .HasName("Id");

            builder.Property(p => p.Id)
                   .HasColumnName("Id");

            builder.Property(p => p.Major)
                .IsRequired();

            builder.Property(p => p.Minor)
                .IsRequired();

            builder.Property(p => p.Patch)
                .IsRequired();

            builder.Property(p => p.PreRelease)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
