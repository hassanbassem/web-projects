using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketBooking.Models.Data.Configurations
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.ToTable("Cinemas");

            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Description)
                .IsUnicode(false)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(c => c.PictureUrl)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
