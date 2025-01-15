using Microsoft.EntityFrameworkCore;
using RecordStoreAPI.DbContexts;
using RecordStoreAPI.Repositories;
using RecordStoreAPI.Services;

namespace RecordStoreAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddScoped<IAlbumsService, AlbumsService>();
        builder.Services.AddScoped<IAlbumsRepository, AlbumsRepository>();

        // Use in-memory database on development environments
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContext<AlbumsDbContext>(options =>
                options.UseInMemoryDatabase("TestInMemoryDb"));
        }
        else
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<AlbumsDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

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

        app.MapControllers();

        app.Run();
    }
}
