using Application;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using WebAPI.Configurations;

namespace WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

        builder.Services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Books Library API",
            });
            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
            var domainXmlPath = Path.Combine(AppContext.BaseDirectory, "Domain.xml");
            options.IncludeXmlComments(domainXmlPath);
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebAPI.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Application.xml"));
            options.SchemaFilter<EnumTypesSchemaFilter>(domainXmlPath);
        });

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.MapControllers();

        app.UseAuthorization();

        app.Run();
    }
}
