using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TM.DotNet.Entities.Tables
{
	
	public class User :  BaseEntity
	{
		
		public int Id { get; set; }

		
		public string Name { get; set; }

	
		public string Email { get; set; }


		public string Password { get; set; }

		public ICollection<TaskAssignment> TaskAssignments { get; set; }
		public ICollection<TaskCompletion> TaskCompletions { get; set; }
	}
}
