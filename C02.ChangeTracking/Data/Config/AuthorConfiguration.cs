﻿using C02.ChangeTracking.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C02.ChangeTracking.Data.Config
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
           .HasColumnType("VARCHAR")
           .HasMaxLength(50).IsRequired();

            builder.ToTable("Authors");
        }
    }
}
