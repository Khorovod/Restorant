using MediatR;
using Orders.Domain.Events;
using Orders.Infrastructure.EventStores;

namespace Orders.Application.EventCommands.Create;

internal class OrderCreateEventCommandHandler : IRequestHandler<OrderCreateEventCommand, int>
{
    private readonly IEventStore _eventStore;

    public OrderCreateEventCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    public Task<int> Handle(OrderCreateEventCommand request, CancellationToken cancellationToken)
    {
        var orderCreatedEvent = new OrderCreatedEvent(request.Id, request.MenuItems);
        _eventStore.SaveEvent(orderCreatedEvent);
        
        return Task.FromResult(request.Id);
    }
}