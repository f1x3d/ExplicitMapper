using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExplicitMapper.Extensions;

public static class ExplicitMapperExtensions
{
    public static IServiceCollection AddExplicitMapper(this IServiceCollection services)
    {
        services.TryAddSingleton<Mappings.ExplicitMapper>();

        return services;
    }
}
