using System;
using System.Collections.Generic;
using System.Text;

namespace Planify.Application.Commands;

public record LoginUserCommand(string Email, string Password);