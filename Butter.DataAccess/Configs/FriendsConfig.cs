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
    internal class FriendsConfig : IEntityTypeConfiguration<FriendEntity>
    {
        public void Configure(EntityTypeBuilder<FriendEntity> builder)
        {
            builder.ToTable("Friends");
            builder.Property(f => f.UserId)
                .IsRequired();
            builder.Property(f => f.FriendId)
                .IsRequired();
            //builder.HasNoKey();
            builder.HasKey(s => new { s.UserId, s.FriendId });

            //Relations
            builder.HasOne(f=>f.Users).WithMany(u=>u.Friends)
                .HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.NoAction);
           
            builder.HasOne(f => f.Friends).WithMany(u => u.MyFriends).HasForeignKey(f => f.FriendId).OnDelete(DeleteBehavior.NoAction);

            //!!!! cardinalités perdues --> donc ajouter trigger pour 0-10!!!
        }
    }
}
