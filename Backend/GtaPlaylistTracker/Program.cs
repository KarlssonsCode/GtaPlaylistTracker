
using GtaPlaylistTracker.Data;
using GtaPlaylistTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace GtaPlaylistTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<PlayerService>();
            builder.Services.AddScoped<PlaylistService>();
            builder.Services.AddScoped<PlaylistResultService>();
            builder.Services.AddScoped<GameService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                    .WithOrigins(app.Configuration["AllowedOrigins"])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
