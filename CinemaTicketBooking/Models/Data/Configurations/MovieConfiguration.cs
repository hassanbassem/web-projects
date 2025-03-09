using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketBooking.Models.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");

            builder.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Title)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Description)
                .IsUnicode(false)
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(m => m.Category)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.PictureUrl)
                .IsUnicode(false)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(m => m.StartDate)
                .IsRequired();

            builder.Property(m => m.EndDate)
                .IsRequired();

            builder.HasOne(m => m.Cinema)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CinemaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Producer)
                .WithMany(p => p.Movies)
                .HasForeignKey(m => m.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Actors)
                .WithMany(a => a.Movies);

            builder.HasMany(m => m.Orders)
                .WithMany(o => o.Movies)
                .UsingEntity<MovieOrder>();

            builder.HasMany(m => m.Users)
                .WithMany(u => u.Movies)
                .UsingEntity<Cart>();

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}
