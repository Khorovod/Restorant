using Orders.Application.Factories;
using Orders.Application.Services;
using Orders.Presentation.Api;

namespace Orders.Application;

public static class ServiceCollectionExtensions
{
    public static void AddOrderService(this IServiceCollection services)
    {
        services.AddSingleton<OrderAggregateFactory>();

        services.AddScoped<IOrderService, OrderService>();
        // кто последний тот и папа :)
        services.AddScoped<IOrderService, OrderEventService>();
    }
}