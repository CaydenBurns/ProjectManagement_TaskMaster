using TM.DotNet.Entities.Tables;

namespace TM.DotNet.Interfaces
{
	public interface IUserService
	{
		public List<User> GetAllUsers();
	}
}
