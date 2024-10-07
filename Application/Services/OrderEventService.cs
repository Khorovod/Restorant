using Mapster;
using MediatR;
using Orders.Application.EventCommands.Complete;
using Orders.Application.EventCommands.Create;
using Orders.Application.EventCommands.Update;
using Orders.Application.Factories;
using Orders.Domain.Dtos;
using Orders.Domain.Models.Enums;
using Orders.Presentation.Api;

namespace Orders.Application.Services;

public class OrderEventService : IOrderService
{
        private readonly ISender _sender;
        private readonly OrderAggregateFactory _factory;

        public OrderEventService(ISender sender, OrderAggregateFactory factory)
        {
            _sender = sender;
            _factory = factory;
        }

        public Task<int> CreateOrder(OrderRequest request)
        {
            var command = new OrderCreateEventCommand(request.Id, request.MenuItems);
            return _sender.Send(command);
        }

        public Task DeleteOrder(int orderId)
        {
            var command = new OrderCompleteEventCommand(orderId, OrderStatus.Canceled);
            return _sender.Send(command);
        }

        public Task<int> ChangeOrder(OrderRequest request)
        {
            var command = new OrderUpdateEventCommand(request.Id, request.MenuItems);
            return _sender.Send(command);
        }

        public Task<OrderStatus> CheckOrderStatus(int orderId)
        {
            var aggregate = _factory.CreateOrderAggregate(orderId);
            
            return Task.FromResult(aggregate.Status);
        }

        public Task<decimal> GetTotalCost(int orderId)
        {
            var aggregate = _factory.CreateOrderAggregate(orderId);
            
            return Task.FromResult(aggregate.TotalPrice);
        }

        public Task<List<OrdersStatusDto>> GetOrders()
        {
            var orders = _factory.CreateAllOrderAggregates();

            var result = orders.Select(o => o.Adapt<OrdersStatusDto>());
            return Task.FromResult(result.ToList());
        }

        public Task<OrdersStatusDto>? GetOrder(int orderId)
        {
            var aggregate = _factory.CreateOrderAggregate(orderId);

            var result = aggregate.Adapt<OrdersStatusDto?>();
            return result is null ? null : Task.FromResult(result);
        }
}