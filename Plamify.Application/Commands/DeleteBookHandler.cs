using MediatR;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Planify.Application.Commands
{
    public class DeleteUserBookCommandHandler : IRequestHandler<DeleteBook, Unit>
    {
        private readonly IAppDbContext _context;

        public DeleteUserBookCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteBook request, CancellationToken cancellationToken)
        {
            var book = await _context.GetUserBookByIdAsync(request.Id, cancellationToken);

            if (book == null)
                throw new Exception("Libro no encontrado");

            await _context.RemoveUserBookAsync(book, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}