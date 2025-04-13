using AdvancedUnitTesting.Models;
using AdvancedUnitTesting.Serivces;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedUnitTesting.Controllers
{
	
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet("getuserbyid")]
		public User GetUserById(int id)
		{
			return _userRepository.GetUserById(id);
		}

		[HttpGet("Userlist")]
		public IEnumerable<User> GetAllUsers()
		{
			return _userRepository.GetAllUsers();
			
		}

		[HttpPost("createuser")]
		public User CreateUser(User user)
		{
			

			_userRepository.AddUser(user);
			return user;
		}

		[HttpPut("updateuser")]
		public User UpdateUser(int id, User user)
		{
			
			return _userRepository.UpdateUser(user);
			
		}

		[HttpDelete("deleteuser")]
		public bool DeleteUser(int id)
		{
			return _userRepository.DeleteUser(id);
			
		}
	}
}
