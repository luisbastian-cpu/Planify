using MediatR;
using Planify.Application.Commands;
using Planify.Application.Common.Interfaces;

namespace Planify.Application.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _repository;

        public DeleteTaskCommandHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}