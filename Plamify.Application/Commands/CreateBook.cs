using System;
using MediatR;
using Planify.Domain.Entities;

namespace Planify.Application.Commands
{
    public class CreateBook : IRequest<int>
    {
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