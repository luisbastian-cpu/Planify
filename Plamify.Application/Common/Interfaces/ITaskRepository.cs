using Planify.Domain.Entities;

namespace Planify.Application.Common.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAllAsync();

        Task AddAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(int id);
    }
}