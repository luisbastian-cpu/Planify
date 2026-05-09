using MediatR;
using Planify.Application.Common.Interfaces;
using Planify.Application.Commands;
using Planify.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Planify.Application.Commands
{
    public class UpdateUserBookCommandHandler : IRequestHandler<UpdateUserBookCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public UpdateUserBookCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.GetUserBookByIdAsync(request.Id, cancellationToken);

            if (book == null)
                throw new Exception("Libro no encontrado");

            if (request.Score < 1 || request.Score > 5)
                throw new Exception("Score inválido");

            book.Title = request.Title;
            book.Author = request.Author;
            book.Link = request.Link;
            book.Score = request.Score;
            book.Status = request.Status;
            book.DateRead = request.DateRead;
            book.Genre = request.Genre;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}