using EasyDDD.Domain.Versions;
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
        }
    }
}
