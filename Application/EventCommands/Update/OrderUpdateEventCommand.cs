using MediatR;
using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Application.EventCommands.Update;

internal record OrderUpdateEventCommand(int Id, MenuItem[] MenuItems) : IRequest<int>;