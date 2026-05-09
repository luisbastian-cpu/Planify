using System;
using System.Collections.Generic;
using System.Text;

namespace Planify.Application.Commands;

public record RegisterUserCommand(string Name, string Email, string Password);
