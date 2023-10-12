using Butter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.DataAccess.Configs
{
    internal class SandwichConfig : IEntityTypeConfiguration<SandwichEntity>
    {
        public void Configure(EntityTypeBuilder<SandwichEntity> builder)
        {
            builder.HasKey(s => s.SandwichId)
                   .IsClustered();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasColumnType("nvarchar")
                   .HasMaxLength(50);
            builder.Property(s=>s.Description)
                   .IsRequired()
                   .HasColumnType("nvarchar")
                   .HasMaxLength(500);
            builder.Property<double>(s => s.Price)
                   .IsRequired();

            builder.Property(s => s.IsVeggie)
                   .HasColumnType("bit")
                   .HasDefaultValue(false);

                   
        }
    }
}
