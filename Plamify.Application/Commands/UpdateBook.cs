using MediatR;
using Planify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planify.Application.Commands
{
    public class UpdateUserBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? Link { get; set; }
        public int Score { get; set; }
        public BookStatus Status { get; set; }
        public DateTime? DateRead { get; set; }
        public required string Genre { get; set; }
    }
}
