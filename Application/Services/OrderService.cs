using Mapster;
using MediatR;
using Orders.Application.Commands.Create;
using Orders.Application.Commands.Delete;
using Orders.Application.Commands.Update;
using Orders.Application.Queries.GetAll;
using Orders.Application.Queries.GetOrder;
using Orders.Domain.Dtos;
using Orders.Domain.Models.Enums;
using Orders.Presentation.Api;

namespace Orders.Application.Services
{
    internal class OrderService : IOrderService
    {
        private readonly ISender _sender;

        public OrderService(ISender sender)
        {
            _sender = sender;
        }

        public Task<int> CreateOrder(OrderRequest request)
        {
            var command = new OrderCreateCommand(request.MenuItems);
            return _sender.Send(command);
        }

        public Task DeleteOrder(int orderId)
        {
            var command = new OrderDeleteCommand(orderId);
            return _sender.Send(command);
        }

        public Task<int> ChangeOrder(OrderRequest request)
        {
            var command = new OrderUpdateCommand(request.Id, request.MenuItems, request.Status);
            return _sender.Send(command);
        }

        public async Task<OrderStatus> CheckOrderStatus(int orderId)
        {
            var command = new GetOrderQuery(orderId);
            var result = await _sender.Send(command);

            return result?.Status ?? OrderStatus.None;
        }

        public async Task<decimal> GetTotalCost(int orderId)
        {
            var command = new GetOrderQuery(orderId);
            var result = await _sender.Send(command);

            return result?.TotalCost ?? 0;
        }

        public async Task<List<OrdersStatusDto>> GetOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _sender.Send(query);
            
            return result.Select(o => o.Adapt<OrdersStatusDto>()).ToList();
        }

        public async Task<OrdersStatusDto>? GetOrder(int orderId)
        {
            var command = new GetOrderQuery(orderId);
            var result = await _sender.Send(command);
            
            return result?.Adapt<OrdersStatusDto>();
        }
    }
}
