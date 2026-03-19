using MediatR;

namespace Planify.Application.Commands
{
    public record UpdateTaskCommand(
        int Id,
        string Title,
        string Description,
        bool Completed
    ) : IRequest;
}