using MediatR;
using Orders.Domain.Models;
using Orders.Domain.Models.Enums;
using Orders.Infrastructure.Repositories;

namespace Orders.Application.Commands.Create;

internal class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, int>
{
    private readonly IOrderRepository _orderRepository;

     public OrderCreateCommandHandler(IOrderRepository orderRepository)
     {
         _orderRepository = orderRepository;
     }

    public async Task<int> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            MenuItems = request.MenuItems.ToList(),
            TotalCost = request.MenuItems.Sum(i => i.Price),
            Status = OrderStatus.Created,
        };
        return await _orderRepository.Create(order, cancellationToken);
    }
}