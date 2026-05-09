using Planify.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Planify.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        Task AddUserBookAsync(UserBook book, CancellationToken cancellationToken);

        Task<UserBook?> GetUserBookByIdAsync(int id, CancellationToken cancellationToken);

        Task RemoveUserBookAsync(UserBook book, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<List<UserBook>> GetUserBooksByUserIdAsync(int userId, CancellationToken cancellationToken);
    }
}