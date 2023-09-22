using C03.CascadeDelete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C03.CascadeDelete.Data.Config
{
    public class BookV2Configuration : IEntityTypeConfiguration<BookV2>
    {
        public void Configure(EntityTypeBuilder<BookV2> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.HasOne(x => x.AuthorV2)
                .WithMany(x => x.BookV2s)
                .HasForeignKey(x => x.AuthorV2Id)
                .IsRequired(false);
            builder.ToTable("BookV2s");
        }
    }
}
