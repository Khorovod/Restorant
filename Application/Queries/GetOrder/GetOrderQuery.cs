using MediatR;
using Orders.Domain.Models;

namespace Orders.Application.Queries.GetOrder;

internal record GetOrderQuery(int Id) : IRequest<Order?>;