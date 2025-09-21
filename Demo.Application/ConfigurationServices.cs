using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Demo.Application;

public static class ConfigurationServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ConfigurationServices).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(ConfigurationServices).Assembly);

        return services;
    }
}
