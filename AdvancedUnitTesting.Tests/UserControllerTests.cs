using AdvancedUnitTesting.Controllers;
using AdvancedUnitTesting.Models;
using AdvancedUnitTesting.Serivces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTesting.Tests
{
	public class UserControllerTests
	{
		private Mock<IUserRepository> _userRepositoryMock;
		private UserController _userController;

		[SetUp]
		public void Setup()
		{
			_userRepositoryMock = new Mock<IUserRepository>();
			_userController = new UserController(_userRepositoryMock.Object);
		}

		[Test]
		public void GetUserList_UserList()
		{
			// Arrange
			var expectedUsers = GetUsersData();
			_userRepositoryMock.Setup(x => x.GetAllUsers())
				.Returns(expectedUsers);

			// Act
			var result = _userController.GetAllUsers();

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count(), Is.EqualTo(expectedUsers.Count));
			Assert.That(result, Is.EquivalentTo(expectedUsers));
		}

		[Test]
		public void GetUserByID_User()
		{
			// Arrange
			var UserList = GetUsersData();
			_userRepositoryMock.Setup(x => x.GetUserById(2))
				.Returns(UserList[1]);

			// Act
			var UserResult = _userController.GetUserById(2);

			// Assert
			Assert.That(UserResult, Is.Not.Null);
			Assert.That(UserResult.Id, Is.EqualTo(UserList[1].Id));
		}

	

		[Test]
		public void AddUser_User()
		{
			// Arrange
			var UserList = GetUsersData();
			_userRepositoryMock.Setup(x => x.AddUser(UserList[2]))
				.Returns(UserList[2]);

			// Act
			var UserResult = _userController.CreateUser(UserList[2]);

			// Assert
			Assert.That(UserResult, Is.Not.Null);
			Assert.That(UserResult.Id, Is.EqualTo(UserList[2].Id));
		}

		[Test]
		public void UpdateUser_ValidUser_UserIsUpdated()
		{
			// Arrange
			var userList = GetUsersData();
			var userToUpdate = userList[0];
			userToUpdate.FirstName = "UpdatedName";

			_userRepositoryMock.Setup(x => x.UpdateUser(userToUpdate))
				.Returns(userToUpdate)
				.Verifiable();

			// Act
			var result = _userController.UpdateUser(userToUpdate.Id, userToUpdate);

			// Assert
			Assert.That(result, Is.InstanceOf<User>());
			var updatedUser = result as User;
			Assert.That(updatedUser.FirstName, Is.EqualTo("UpdatedName"));
			_userRepositoryMock.Verify(x => x.UpdateUser(userToUpdate), Times.Once);



		
		}

		[Test]
		public void DeleteUser_ExistingUserId_UserIsDeleted()
		{
			// Arrange
			var userIdToDelete = 1;
			

			_userRepositoryMock.Setup(x => x.DeleteUser(userIdToDelete))
				.Returns(true);

			// Act
			var result = _userController.DeleteUser(userIdToDelete);

			// Assert
			Assert.That(result, Is.True);




		}


		private List<User> GetUsersData()
		{
			return new List<User>
			{
				new User
				{
					Id = 1,
					FirstName = "Adam",
					LastName ="Anas",
					Email="user12@gmail.com"
				},
				new User
				{
					Id = 2,
					FirstName = "Fawaz",
					LastName ="Ahmed",
					Email="user13@gmail.com"
				},
				new User
				{
					Id = 3,
					FirstName = "sarah",
					LastName ="Ahmed",
					Email="user14@gmail.com"
				},
			};
		}
	}
}


