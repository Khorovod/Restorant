using MediatR;
using Orders.Domain.Models;

namespace Orders.Application.Queries.GetAll;

internal record GetAllOrdersQuery : IRequest<IEnumerable<Order>>;