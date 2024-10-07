using MediatR;
using Orders.Domain.Events;
using Orders.Infrastructure.EventStores;

namespace Orders.Application.EventCommands.Complete;

internal class OrderCompleteEventCommandHandler : IRequestHandler<OrderCompleteEventCommand>
{
    private readonly IEventStore _eventStore;

    public OrderCompleteEventCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    public Task Handle(OrderCompleteEventCommand request, CancellationToken cancellationToken)
    {
        var orderCompletedEvent = new OrderCompletedEvent(request.Id, request.Status);
        _eventStore.SaveEvent(orderCompletedEvent);
        
        return Task.CompletedTask;
    }
}