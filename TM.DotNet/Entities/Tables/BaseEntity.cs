using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TM.DotNet.Entities.Tables
{
	
	public class BaseEntity
	{
		
		public DateTime DateCreated { get; set; }
		public DateTime DateChanged { get; set; }
	}

}
