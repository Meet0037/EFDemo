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
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.HasKey(ba => new { ba.Book_Id, ba.Author_Id });
            modelBuilder.HasOne(ba => ba.Book).WithMany(b => b.BookAuthorMap).HasForeignKey(ba => ba.Book_Id);
            modelBuilder.HasOne(ba => ba.Author).WithMany(b => b.BookAuthorMap).HasForeignKey(ba => ba.Author_Id);
        }
    }   
}
