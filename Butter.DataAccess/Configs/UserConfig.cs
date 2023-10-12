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
    internal class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId)
                   .IsClustered();

            builder.Property(u => u.NickName)
                   .IsRequired()
                   .HasColumnType("nvarchar")
                   .HasMaxLength(250);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(254);

            builder.Property(u => u.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(u => u.Town)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            builder.Property(u => u.Genre)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(254);

            //relations zamis 


        }
    }
}
