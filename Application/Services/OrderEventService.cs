using Mapster;
using MediatR;
using Orders.Application.EventCommands.Complete;
using Orders.Application.EventCommands.Create;
using Orders.Application.EventCommands.Update;
using Orders.Domain.Dtos;
using Orders.Domain.Models.Enums;
using Orders.Infrastructure.Projections;
using Orders.Presentation.Api;

namespace Orders.Application.Services;

public class OrderEventService : IOrderService
{
        private readonly ISender _sender;
        private readonly IOrdersProjection _projection;

        public OrderEventService(ISender sender, IOrdersProjection projection)
        {
            _sender = sender;
            _projection = projection;
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
            var aggregate = _projection.GetOrder(orderId);

            if (aggregate == null)
            {
                throw new ArgumentException(nameof(orderId));
            }
            
            return Task.FromResult(aggregate.Status);
        }

        public Task<decimal> GetTotalCost(int orderId)
        {
            var aggregate = _projection.GetOrder(orderId);
            
            if (aggregate == null)
            {
                throw new ArgumentException(nameof(orderId));
            }
            
            return Task.FromResult(aggregate.TotalPrice);
        }

        public Task<List<OrdersStatusDto>> GetOrders()
        {
            var orders = _projection.GetOrders().ToList();

            var result = orders.Select(o => o.Adapt<OrdersStatusDto>());
            return Task.FromResult(result.ToList());
        }

        public Task<OrdersStatusDto> GetOrder(int orderId)
        {
            var aggregate = _projection.GetOrder(orderId);
            
            if (aggregate == null)
            {
                throw new ArgumentException(nameof(orderId));
            }
            
            return Task.FromResult(aggregate.Adapt<OrdersStatusDto>());
        }
}