using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTicketBooking.Models.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FName)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(u => u.LName)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsUnicode(false)
                .HasMaxLength(30)
                .IsRequired();
            
            builder.Property(u => u.UserName)
                .IsUnicode(false)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsUnicode(false)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
        }
    }
}
