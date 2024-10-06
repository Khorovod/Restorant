using MediatR;
using Orders.Domain.Models;
using Orders.Domain.Models.Enums;

namespace Orders.Application.Commands.Update;

internal record OrderUpdateCommand(int Id, MenuItem[] MenuItems, OrderStatus Status) : IRequest<int>;