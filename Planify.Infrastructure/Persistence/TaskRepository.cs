using Microsoft.EntityFrameworkCore;
using Planify.Application.Common.Interfaces;
using Planify.Domain.Entities;

namespace Planify.Infrastructure.Persistence;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        var existing = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

        if (existing != null)
        {
            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.Completed = task.Completed;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}