using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollApp.Domain.Entities;

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
            builder.Property(x => x.Views).HasDefaultValue(0).IsRequired();

            //FK
            builder.HasMany(x => x.Options).WithOne().OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}
