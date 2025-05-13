using Microsoft.Extensions.DependencyInjection;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Pagination;
using System.Reflection;

using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;
using MediatorEntity = MapMyJourneyAPI.Application.Mediator.Mediator;

namespace MapMyJourneyAPI.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        services.AddScoped<IMediator, MediatorEntity>();

        // Dynamically register all IRequestHandler and INotificationHandler implementations
        var assembly = Assembly.GetExecutingAssembly();

        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType &&
                (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                 i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))));

        foreach (var handlerType in handlerTypes)
        {
            var interfaces = handlerType.GetInterfaces()
                .Where(i => i.IsGenericType &&
                    (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                     i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, handlerType);
            }
        }

        return services;
    }
}