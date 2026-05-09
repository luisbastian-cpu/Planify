using MediatR;
using Planify.Application.Commands;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;

public class CreateUserBookCommandHandler : IRequestHandler<CreateBook, int>
{
    private readonly IAppDbContext _context;

    public CreateUserBookCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBook request, CancellationToken cancellationToken)
    {
        if (request.Score < 1 || request.Score > 5)
            throw new Exception("Score inválido");

        var book = new UserBook
        {
            UserId = request.UserId,
            Title = request.Title,
            Author = request.Author,
            Link = request.Link,
            Score = request.Score,
            Status = request.Status,
            DateRead = request.DateRead,
            Genre = request.Genre
        };

        await _context.AddUserBookAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}