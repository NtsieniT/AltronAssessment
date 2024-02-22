using Core.Interfaces;
using Core.Models;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltronAssessment.Tests
{
    [TestClass]
    public class UsersTests
    {
        private IUsers _usersService;
        public UsersTests(IUsers usersService)
        {
            _usersService = usersService;
        }

        public UsersTests()
        {
            
        }


        [TestMethod]
        public void AddUser()
        {
            var user = new UsersRequest()
            {
                FirstName = "Ntsieni2",
                LastName = "Tshikhakhisa2",
                Email = "Tshikhakhisan@gmail.com2",
                Gender = "Male",
                Country = "South Africa",
                City = "Pretoria",
                DateOfBirth = DateTime.Now,
                IdNumber = "9206036015083",
                PhoneNumber = "0792783081"
            };
            var userResponse = _usersService.AddUser(user);
            Assert.IsNotNull(userResponse);
        }

        [TestMethod]
        public void GetAllUser() 
        {
            var userResponse = _usersService.GetUsers();
            Assert.IsNotNull(userResponse);
        }

        [TestMethod]
        public void GetUserById()
        {
            var userResponse = _usersService.GetUserById(1);
            Assert.IsNotNull(userResponse);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var user = new UsersRequest()
            {
                FirstName = "Ntsieni2",
                LastName = "Tshikhakhisa2",
                Email = "Tshikhakhisan@gmail.com2",
                Gender = "Male",
                Country = "South Africa",
                City = "Pretoria",
                DateOfBirth = DateTime.Now,
                IdNumber = "9206036015083",
                PhoneNumber = "0792783081"
            };
            var userResponse = _usersService.UpdateUser(1, user);
            Assert.IsNotNull(userResponse);
            Assert.IsTrue(userResponse.Result == true);
        }


        [TestMethod]
        public void DeleteUser()
        {
            var userResponse = _usersService.DeleteUser(1); 

            Assert.IsNotNull(userResponse);
            Assert.IsTrue(userResponse.Result == true);

        }
    }
}
