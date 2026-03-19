using MediatR;
using Planify.Domain.Entities;

namespace Planify.Application.Queries
{
    public record GetTasksQuery() : IRequest<List<TaskItem>>;
}