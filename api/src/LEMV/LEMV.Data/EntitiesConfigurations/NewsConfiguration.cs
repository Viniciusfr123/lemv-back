using LEMV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LEMV.Data.EntitiesConfigurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Subject).IsRequired();
            builder.Property(x => x.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.YoutubeUrl);

            builder
                .HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId);

            builder
                .HasOne(x => x.Laboratory)
                .WithMany()
                .HasForeignKey(x => x.LaboratoryId);

            builder.Property(x => x.CurrentState).IsRequired();

            builder.ToTable(nameof(News));
        }
    }
}