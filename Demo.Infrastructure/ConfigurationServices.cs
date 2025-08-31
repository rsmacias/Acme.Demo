using Demo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure;

public static class ConfigurationServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__AcmeDb") ?? configuration.GetConnectionString("AcmeDb");

        services.AddDbContext<DemoContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
