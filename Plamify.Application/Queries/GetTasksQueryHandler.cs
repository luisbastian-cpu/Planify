using MediatR;
using Planify.Application.Common.Interfaces;
using Planify.Application.Queries;
using Planify.Domain.Entities;

namespace Planify.Application.Handlers
{
    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskItem>>
    {
        private readonly ITaskRepository _repository;

        public GetTasksQueryHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskItem>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}