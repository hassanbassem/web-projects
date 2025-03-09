using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketBooking.Models.Data.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(p => p.UniqueName);

            builder.Property(p => p.FilenameAtClient).HasMaxLength(255).IsUnicode(false).IsRequired();

            builder.HasOne(p => p.Movie).WithOne(m => m.Picture).HasForeignKey<Movie>(m => m.PictureUrl).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Artist).WithOne(a => a.Picture).HasForeignKey<Artist>(p => p.PictureUrl).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Cinema).WithOne(c => c.Picture).HasForeignKey<Cinema>(p => p.PictureUrl).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
