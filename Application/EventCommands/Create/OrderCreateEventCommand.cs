using MediatR;
using Orders.Domain.Models;

namespace Orders.Application.EventCommands.Create;

internal record OrderCreateEventCommand(int Id, MenuItem[] MenuItems) : IRequest<int>;

