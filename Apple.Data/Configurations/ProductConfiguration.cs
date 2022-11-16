using Apple.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("tbl_Products");
            builder.Property(x => x.Name).HasColumnName("ProductName");
            builder.Property(x => x.Description).HasColumnName("ProductDesc");
            builder.Property(x => x.DisCount).HasColumnName("Dis%");
            builder.HasOne(x => x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId).HasConstraintName("ForeignKey_Category_And_Products");
            builder.HasQueryFilter(x =>x.IsDelete);


        }
    }
}
