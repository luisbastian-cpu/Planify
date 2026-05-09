using System;

namespace Planify.Domain.Entities
{
    public class UserBook
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