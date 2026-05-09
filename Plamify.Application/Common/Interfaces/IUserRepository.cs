using System;
using System.Collections.Generic;
using System.Text;
using Planify.Domain.Entities;

namespace Planify.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User> AddAsync(User user);
    Task<List<User>> GetAllAsync();
}
