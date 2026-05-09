using MediatR;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Planify.Application.Queries
{
    public class GetUserBooksQueryHandler : IRequestHandler<GetUserBooksQuery, List<UserBook>>
    {
        private readonly IAppDbContext _context;

        public GetUserBooksQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserBook>> Handle(GetUserBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetUserBooksByUserIdAsync(request.UserId, cancellationToken);
        }
    }
}