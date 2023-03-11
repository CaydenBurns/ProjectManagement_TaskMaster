using TM.DotNet.Entities;
using TM.DotNet.Entities.Tables;
using TM.DotNet.Interfaces;

namespace TM.DotNet.Services
{
	public class UserService : IUserService
	{
		private readonly TmDbContext _dbContext;

		private List<User> _allUsers;


		public UserService(TmDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<User> GetAllUsers()
		{
			using var context = _dbContext;
			var users = from user in context.Users
				select user;
			List<User> allUsers = new List<User>();
			foreach (var user in users)
			{
				allUsers.Add(user);
				
			}
			return allUsers;
			
			
		}
	}
}
