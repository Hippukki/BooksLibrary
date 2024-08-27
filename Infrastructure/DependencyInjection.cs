using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("postgresql")));
        services.AddScoped<IAuthorsRepository, AuthorsRepository>();
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IPublishersRepository, PublishersRepository>();

        return services;
    }
}
