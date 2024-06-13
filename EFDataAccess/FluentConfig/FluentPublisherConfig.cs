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
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            //use Fluent API for data annotation in FLuent_Publisher
            modelBuilder.HasKey(p => p.Publisher_Id);
            modelBuilder.Property(p => p.Name).IsRequired();
        }   
    }   
}
