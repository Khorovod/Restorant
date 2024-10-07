using MediatR;
using Orders.Domain.Models.Enums;

namespace Orders.Application.EventCommands.Complete;

internal record OrderCompleteEventCommand(int Id, OrderStatus Status) : IRequest;