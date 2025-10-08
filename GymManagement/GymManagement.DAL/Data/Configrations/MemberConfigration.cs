using GymManagement.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Data.Configrations
{
    public class MemberConfigration : GymUserConfigrations<Member>, IEntityTypeConfiguration<Member>
    {

        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Created_at)
                .HasColumnName("JoinDate")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
