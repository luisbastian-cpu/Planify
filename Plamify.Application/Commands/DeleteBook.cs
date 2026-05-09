using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planify.Application.Commands
{
    public class DeleteBook : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
