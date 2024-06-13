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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            //use Fluent API for data annotation in FLuent_BookDetail
            modelBuilder.ToTable("Fluent_BookDetails");
            modelBuilder.Property(bd => bd.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.HasKey(bd => bd.BookDetail_Id);
            modelBuilder.Property(bd => bd.NumberOfChapters).IsRequired();
            modelBuilder.HasOne(bd => bd.Book).WithOne(b => b.BookDetail).HasForeignKey<Fluent_BookDetail>(bd => bd.Book_Id);
        }
    }
}
