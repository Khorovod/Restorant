using MediatR;
using Orders.Infrastructure.Repositories;

namespace Orders.Application.Commands.Delete;

internal class OrderDeleteCommandHandler : IRequestHandler<OrderDeleteCommand>
{
    private readonly IOrderRepository _orderRepository;

    public OrderDeleteCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Task Handle(OrderDeleteCommand request, CancellationToken cancellationToken)
    {
        return _orderRepository.Delete(request.Id, cancellationToken);
    }
}