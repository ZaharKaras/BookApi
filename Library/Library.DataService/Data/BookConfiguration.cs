using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataService.Data
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ISBN)
                .HasMaxLength(50);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Genre)
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.Author)
                .HasMaxLength(100);

            builder.Property(e => e.BorrowedTime)
                .IsRequired();

            builder.Property(e => e.ReturnTime)
                .IsRequired();
        }
    }
}
