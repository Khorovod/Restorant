using MediatR;

namespace Orders.Application.Commands.Delete;

internal record OrderDeleteCommand(int Id) : IRequest;