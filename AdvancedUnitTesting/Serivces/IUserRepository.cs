using AdvancedUnitTesting.Models;

namespace AdvancedUnitTesting.Serivces
{
	public interface IUserRepository
	{
		public User GetUserById(int id);
		public IEnumerable<User> GetAllUsers();
		public User AddUser(User User);
		public User UpdateUser(User User);
		public bool DeleteUser(int Id);
	}
}
