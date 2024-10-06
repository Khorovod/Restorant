using MediatR;
using Orders.Domain.Models;
using Orders.Infrastructure.Repositories;

namespace Orders.Application.Commands.Update;

internal class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public OrderUpdateCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task<int> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = request.Id,
            MenuItems = request.MenuItems.ToList(),
            TotalCost = request.MenuItems.Sum(i => i.Price),
            Status = request.Status
        };
        
        return _orderRepository.Update(order, cancellationToken);
    }
}