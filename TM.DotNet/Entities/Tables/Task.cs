using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace TM.DotNet.Entities.Tables
{
	public class Task : BaseEntity
	{
		
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Title { get; set; }

		[MaxLength(250)]
		public string Description { get; set; }

		public ICollection<TaskAssignment> TaskAssignments { get; set; }
		public ICollection<TaskCompletion> TaskCompletions { get; set; }
	}
}
