using MediatR;
using Planify.Domain.Entities;
using System.Collections.Generic;

namespace Planify.Application.Queries
{
    public class GetUserBooksQuery : IRequest<List<UserBook>>
    {
        public int UserId { get; set; }
    }
}