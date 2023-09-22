using C03.CascadeDelete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C03.CascadeDelete.Data.Config
{
    public class AuthorV2Configuration : IEntityTypeConfiguration<AuthorV2>
    {
        public void Configure(EntityTypeBuilder<AuthorV2> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
           .HasColumnType("VARCHAR")
           .HasMaxLength(50).IsRequired();

            builder.ToTable("AuthorV2s");
        }
    }
}
