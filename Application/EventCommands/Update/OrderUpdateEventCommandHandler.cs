using MediatR;
using Orders.Application.Commands.Update;
using Orders.Domain.Events;
using Orders.Domain.Models;
using Orders.Infrastructure.EventStores;
using Orders.Infrastructure.Repositories;

namespace Orders.Application.EventCommands.Update;

internal class OrderUpdateEventCommandHandler : IRequestHandler<OrderUpdateEventCommand, int>
{
    private readonly IEventStore _eventStore;

    public OrderUpdateEventCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    
    public Task<int> Handle(OrderUpdateEventCommand request, CancellationToken cancellationToken)
    {
        var updateEvent = new OrderUpdateEvent(request.Id, request.MenuItems);
        _eventStore.SaveEvent(updateEvent);
        
        return Task.FromResult(updateEvent.Id);
    }
}