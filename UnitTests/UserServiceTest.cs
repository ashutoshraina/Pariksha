using EFRepository.Infrastructure;
using Moq;
using NUnit.Framework;
using ParikshaModel.Model;
using ParikshaServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class UserServiceTest
    {
        private static IRepository<UserDetail> _repository;
        
        private UserService _service;
        
        private IEnumerable<UserDetail> _users;
        
        private IUnitOfWork _unitOfWork;
        
        private UserDetail _user;

        public TestContext TextContext { get; set; }
        
        public Mock<IRepository<UserDetail>> MockRepository { get; set; } 

        /// <summary>
        /// Initialize() is called once during test execution before test methods in test class are executed.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialize()
        {
            MockRepository = new Mock<IRepository<UserDetail>>();
            _user = new UserDetail { Name = "Ashutosh", Password = "Password", UserRole = UserRole.Admin, DateOfCreation = DateTime.UtcNow };
            _users = new List<UserDetail> { _user };
            _users = _users.Concat(new List<UserDetail> 
                        {
                        new UserDetail { Name = "Monny", Password = "Password1", UserRole = UserRole.DeparmentHead, DateOfCreation = DateTime.UtcNow },
                        new UserDetail { Name = "Jhonny", Password = "Password2", UserRole = UserRole.Principal, DateOfCreation = DateTime.UtcNow },
                        new UserDetail { Name = "Pony", Password = "Password3", UserRole = UserRole.Student, DateOfCreation = DateTime.UtcNow },
                        new UserDetail { Name = "Tony", Password = "Password4", UserRole = UserRole.Teacher, DateOfCreation = DateTime.UtcNow },
                        new UserDetail { Name = "Sunny", Password = "Password4", UserRole = UserRole.Admin, DateOfCreation = DateTime.UtcNow }
                        });

            MockRepository.Setup(_ => _.Query()).Returns(_users.AsQueryable());
            MockRepository.Setup(_ => _.Add(_user)).Returns(_user);
            MockRepository.Setup(_ => _.Remove(_user)).Returns(_user);
            _repository = MockRepository.Object;
            _service = new UserService(_repository, _unitOfWork);
        }

        /// <summary>
        /// Cleanup() is called once during test execution after test methods in class have executed unless
        /// test class' Initialize() method throws an exception.
        /// </summary>
        [TestFixtureTearDown]
        public void Cleanup()
        {
            _repository = null;
            _service = null;
            _users = null;
            _unitOfWork = null;
            MockRepository = null;           
        }

        [Test]
        [Category("UserService")]
        [Description("Checks if a new User is created correctly")]
        public void CreateUserCheck()
        {            
            var result = _service.CreateNewUser(_user);
            Assert.IsNotNull(result);
        }

        [Test]
        [Category("UserService")]
        [Description("Checks if the password of the user is strong enough for acceptance")]
        [TestCase("Password1989")]
        [TestCase("Awesome1989")]
        [TestCase("@wesome$567B")]
        [TestCase("Billa786")]
        [TestCase("*)(&*&9iA")]
        public void CheckForStrongPassword(string password)
        {
           var result = _service.IsStrongPassword(password);
           Assert.IsTrue(result);
        }

        [Test]
        [Category("UserService")]
        [Description("Checks if the password of the user is strong enough for acceptance")]
        [TestCase("pass")]
        [TestCase("pass1")]
        [TestCase("password")]
        [TestCase("Password198919891891")]
        [TestCase("123456789")]
        [TestCase("@wesome$567")]
        [TestCase("Zaaabbb1989")]
        public void CheckForWeakPassword(string password)
        {
            var result = _service.IsStrongPassword(password);
           Assert.IsFalse(result);
        }

        [Test]
        [Category("UserService")]
        [Description("Checks if the User is removed correctly")]
        public void RemoveUserCheck()
        {
            var result = _service.RemoveUser(_user);
            Assert.IsNotNull(result);
        }

        [Test]
        [Category("UserService")]
        [Description("Checks if the Users are fetched correctly by role")]
        [TestCase(UserRole.Admin)]
        [TestCase(UserRole.DeparmentHead)]
        [TestCase(UserRole.Principal)]
        [TestCase(UserRole.Student)]
        [TestCase(UserRole.Teacher)]
        public void GetUsersByRoleCheck(UserRole userRole)
        {
            var result = _service.GetAllUsersByRole(userRole);
            Assert.IsNotNull(result);
            Assert.GreaterOrEqual(result.Count(), 1);
        }
    }
}