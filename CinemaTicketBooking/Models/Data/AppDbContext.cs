using CinemaTicketBooking.Models.Entities;
using CinemaTicketBooking.Models.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace CinemaTicketBooking.Models.Data
{
    public class AppDbContext: DbContext
    {
        private readonly IEnumerable<IInterceptor> _interceptors;

        public AppDbContext(IEnumerable<IInterceptor> interceptor)
        {
            _interceptors = interceptor;
        }

        public DbSet<Artist> Artists { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Cart> CartInfo { get; set; } = null!;
        public DbSet<Cinema> Cinemas { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<MovieOrder> MovieOrders { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Picture> Picture { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string? connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetConnectionString("cinemaTicketBookingDatabase");

            if (connectionString != null )
                optionsBuilder.UseSqlServer(connectionString)
                    .AddInterceptors(_interceptors)
                    .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
