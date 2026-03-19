using MediatR;
using Planify.Application.Commands;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;

namespace Planify.Application.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public UpdateTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        
        public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Completed = request.Completed
            };

            await _repository.UpdateAsync(task);

            
        }
    }
}