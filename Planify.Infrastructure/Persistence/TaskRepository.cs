using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;

namespace Planify.Infrastructure.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private static List<TaskItem> _tasks = new();

        public Task<List<TaskItem>> GetAllAsync()
        {
            return Task.FromResult(_tasks);
        }

        public Task AddAsync(TaskItem task)
        {
            task.Id = _tasks.Count + 1;
            _tasks.Add(task);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(TaskItem task)
        {
            var existing = _tasks.FirstOrDefault(x => x.Id == task.Id);

            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.Completed = task.Completed;
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var task = _tasks.FirstOrDefault(x => x.Id == id);

            if (task != null)
                _tasks.Remove(task);

            return Task.CompletedTask;
        }
    }
}