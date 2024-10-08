﻿using Microsoft.EntityFrameworkCore;
using Orders.Infrastructure.DbContexts;
using Orders.Infrastructure.EventStores;
using Orders.Infrastructure.Projections;
using Orders.Infrastructure.Repositories;

namespace Orders.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddStorage(this IServiceCollection services)
    {
        services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase("Orders"));
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        services.AddSingleton<IEventStore, InMemoryEventStore>();
        services.AddSingleton<IOrdersProjection, OrdersProjection>();
    }
}