using CinemaTicketBooking.Models;
using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Interceptors;
using CinemaTicketBooking.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CinemaTicketBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddScoped<MovieRepository>();

            builder.Services.AddScoped<CinemaRepository>();

            builder.Services.AddScoped<ProducerRepository>();

            builder.Services.AddScoped<ActorRepository>();

            builder.Services.AddScoped<UserRepository>();

            builder.Services.AddScoped<PictureRepository>();

            builder.Services.AddScoped<IFileLoader, PictureLoader>();

            builder.Services.AddSingleton<IInterceptor, SoftDeleteInterceptor>();

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                    context.Response.Redirect("http://localhost:5249/home/error404");
            });

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=index}/{id?}");
                //pattern: "{controller=movies}/{action=index}/{id=1}");

            app.Run();
        }
    }
}