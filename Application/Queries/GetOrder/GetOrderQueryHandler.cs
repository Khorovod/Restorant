using MediatR;
using Orders.Domain.Models;
using Orders.Infrastructure.Repositories;

namespace Orders.Application.Queries.GetOrder;

internal class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<Order?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return _orderRepository.GetById(request.Id, cancellationToken);
    }
}