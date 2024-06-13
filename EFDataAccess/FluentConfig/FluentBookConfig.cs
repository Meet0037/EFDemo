using EFModels.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            //use Fluent API for data annotation in FLuent_Book
            modelBuilder.Property(b => b.ISBN).HasMaxLength(50);
            modelBuilder.HasKey(b => b.BookId);
            modelBuilder.Property(b => b.ISBN).IsRequired();
            modelBuilder.Ignore(b => b.PriceRange);
            modelBuilder.HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.Publisher_Id);
        }   
    }   
}
