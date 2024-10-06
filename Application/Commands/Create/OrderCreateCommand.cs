using MediatR;
using Orders.Domain.Models;

namespace Orders.Application.Commands.Create;

internal record OrderCreateCommand(MenuItem[] MenuItems) : IRequest<int>;

