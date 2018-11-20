using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PollApp.Infra.Persistence.EF.Maps
{
    public class PollMap : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("Poll");
            
            //PK
            builder.HasKey(x => x.ID);

            //Other columns
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();

            //Ignore columns
            //builder.Ignore(x => x.Options);
        }
    }
}
