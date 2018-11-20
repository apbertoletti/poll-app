using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollApp.Infra.Persistence.EF.Maps
{
    public class PollOptionMap : IEntityTypeConfiguration<PollOption>
    {
        public void Configure(EntityTypeBuilder<PollOption> builder)
        {
            builder.ToTable("PollOption");

            //PK
            builder.HasKey(x => x.ID);

            //Other columns
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Votes).HasDefaultValue(0).IsRequired();
        }
    }
}
