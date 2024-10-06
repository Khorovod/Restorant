using Orders.Application.Services;
using Orders.Presentation.Api;

namespace Orders.Application;

public static class ServiceCollectionExtensions
{
    public static void AddOrderService(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
    }
}