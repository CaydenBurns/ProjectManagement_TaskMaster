using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TM.DotNet.Entities.Tables;
using Task = TM.DotNet.Entities.Tables.Task;

namespace TM.DotNet.Entities
{
	public class TmDbContext : DbContext
	{
		public TmDbContext(DbContextOptions<TmDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<TaskAssignment> TaskAssignments { get; set; }
		public DbSet<TaskCompletion> TaskCompletions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.HasKey(u => u.Id);

			modelBuilder.Entity<Task>()
				.HasKey(t => t.Id);

			modelBuilder.Entity<TaskCompletion>()
				.HasKey(tc => tc.Id);

			modelBuilder.Entity<TaskAssignment>()
				.HasKey(ta => new { ta.UserId, ta.TaskId });

			modelBuilder.Entity<User>()
				.HasMany(u => u.TaskAssignments)
				.WithOne(ta => ta.User)
				.HasForeignKey(ta => ta.UserId);

			modelBuilder.Entity<Task>()
				.HasMany(t => t.TaskAssignments)
				.WithOne(ta => ta.Task)
				.HasForeignKey(ta => ta.TaskId);

			modelBuilder.Entity<User>()
				.HasMany(u => u.TaskCompletions)
				.WithOne(tc => tc.User)
				.HasForeignKey(tc => tc.UserId);

			modelBuilder.Entity<Task>()
				.HasMany(t => t.TaskCompletions)
				.WithOne(tc => tc.Task)
				.HasForeignKey(tc => tc.TaskId);
		}
	}
}