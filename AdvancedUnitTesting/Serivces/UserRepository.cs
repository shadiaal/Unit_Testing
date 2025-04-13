using AdvancedUnitTesting.Data;
using AdvancedUnitTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedUnitTesting.Serivces
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;

		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		
		//Read
		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}
		public User GetUserById(int id)
		{
			return _context.Users.Where(x => x.Id == id).FirstOrDefault();
		}
		//Create
		public User AddUser(User User)
		{
			var result = _context.Users.Add(User);
			_context.SaveChanges();
			return result.Entity;
		}
		//Update
		public User UpdateUser(User User)
		{
			var result = _context.Users.Update(User);
			_context.SaveChanges();
			return result.Entity;
		}
		//Delete
		public bool DeleteUser(int Id)
		{
			var filteredData = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
			var result = _context.Remove(filteredData);
			_context.SaveChanges();
			return result != null ? true : false;
		}


	}
}







	
