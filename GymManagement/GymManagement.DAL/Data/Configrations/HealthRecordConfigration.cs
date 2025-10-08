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
    public class HealthRecordConfigration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.ToTable("Members").HasKey(x => x.Id);

            builder.HasOne<Member>()
                .WithOne(x => x.HealthRecord)
                .HasForeignKey<HealthRecord>(x => x.Id);

            builder.Ignore(x => x.Created_at);
            builder.Ignore(x => x.Updated_at);
        }
    }
}
