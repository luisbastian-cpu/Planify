using MediatR;
using Planify.Application.Commands;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;

namespace Planify.Application.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _repository;

        public CreateTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                Completed = false
            };

            await _repository.AddAsync(task);

            return task.Id;
        }
    }
}