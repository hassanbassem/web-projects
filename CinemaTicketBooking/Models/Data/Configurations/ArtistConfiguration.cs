using CinemaTicketBooking.Models.Entities;
using CinemaTicketBooking.Models.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketBooking.Models.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists");

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.Bio)
                .IsUnicode(false)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(a => a.PictureUrl)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
