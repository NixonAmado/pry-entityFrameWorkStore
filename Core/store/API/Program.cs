//contenedor de dependencias
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using API.Extensions;
using System.Reflection;

internal class Programa
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        //enlazar el corrs
        builder.Services.ConfigureCors();
        builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
        builder.Services.AddAplicationServices();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddDbContext<StoreContext>(optionsBuilder =>
        {
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        );

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            //se usa para poder hacer pruebas de peticiones
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //Usar el cors
        app.UseCors("CorsPolicy");
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}