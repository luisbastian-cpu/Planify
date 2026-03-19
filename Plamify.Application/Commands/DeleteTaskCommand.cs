using MediatR;

namespace Planify.Application.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest;
}