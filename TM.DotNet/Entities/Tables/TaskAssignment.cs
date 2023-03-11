using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TM.DotNet.Entities.Tables
{
	public class TaskAssignment : BaseEntity
	{	
		
		public int UserId { get; set; }


		public int TaskId { get; set; }

		[Required]
		public bool IsAssigned { get; set; }

		public User User { get; set; }
		public Task Task { get; set; }
	}
}
