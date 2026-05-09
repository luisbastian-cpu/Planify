using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Planify.Domain.Entities;
using Planify.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Planify.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<UserBook> UserBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasIndex(u => u.Email)
                .IsUnique();

            entity.Property(u => u.PasswordHash)
                .IsRequired();
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(t => t.Description)
                .HasMaxLength(500);
        });

        modelBuilder.Entity<UserBook>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(b => b.Link)
                .HasMaxLength(500);

            entity.Property(b => b.Score)
                .IsRequired();

            entity.Property(b => b.Genre)
                .HasMaxLength(100);

            entity.Property(b => b.Status)
                .HasConversion<string>();

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(b => b.UserId);
        });
    }


    public async Task AddUserBookAsync(UserBook book, CancellationToken cancellationToken)
    {
        await UserBooks.AddAsync(book, cancellationToken);
    }

    public async Task<UserBook?> GetUserBookByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await UserBooks
            .AsNoTracking() 
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task<List<UserBook>> GetUserBooksByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await UserBooks
            .AsNoTracking() 
            .Where(b => b.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public Task RemoveUserBookAsync(UserBook book, CancellationToken cancellationToken)
    {
        UserBooks.Remove(book);
        return Task.CompletedTask;
    }
}