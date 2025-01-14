using Microsoft.EntityFrameworkCore;
using RecordShopAPI.DbContexts;
using RecordShopAPI.Repositories;
using RecordShopAPI.Services;

namespace RecordShopAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        builder.Services.AddScoped<IRecordsService, RecordsService>();
        builder.Services.AddScoped<IRecordsRepository, RecordsRepository>();

        // Use in-memory database on development environments
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContext<RecordsDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
        }
        else
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<RecordsDbContext>(options =>
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
