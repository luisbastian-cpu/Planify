using MediatR;

namespace Planify.Application.Commands
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<int>;
}