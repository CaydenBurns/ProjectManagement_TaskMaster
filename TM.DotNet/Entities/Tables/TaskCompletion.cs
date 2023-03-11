using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TM.DotNet.Entities.Tables
{
	public class TaskCompletion : BaseEntity
	{
		
		public int Id { get; set; }

		
		public int UserId { get; set; }

		[Required]
		public int TaskId { get; set; }

		[Required]
		public bool IsCompleted { get; set; }

		public User User { get; set; }
		public Task Task { get; set; }
	}
}
