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
    [TestFixture]
    public class TestServiceTest
    {
        private IRepository<Test> _repository;
        
        private TestService _service;
        
        private ICollection<Question> _questions;
        
        private IUnitOfWork _unitOfWork;
        
        private IEnumerable<Test> _tests;
        
        private Subject _subject;
        
        private UserDetail _user;
        
        private Test _test;

        public TestContext TestContext { get; set; }
        
        public Mock<IRepository<Test>> MockRepository { get; set; }
        
        /// <summary>
        /// Initialize() is called once during test execution before test methods in test class are executed.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialize()
        {
            MockRepository = new Mock<IRepository<Test>>();

            var firstQuestion = new Question { QuestionId = 1, Difficulty = Difficulty.Hard, Rating = 5 };
            var secondQuestion = new Question { QuestionId = 2, Difficulty = Difficulty.Hard, Rating = 3 };
            var brief = new Brief { Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?", Answer = "It wasn't me" };
            var choice = new Choice { Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?", Choices = "Me,You,All of us all are the culprits", Answers = "Me", IsMultiplechoice = true };
            
            _questions = new List<Question> { firstQuestion, secondQuestion, brief, choice };
            _user = new UserDetail { Name = "Ashutosh", Password = "Password", UserRole = UserRole.Admin, DateOfCreation = DateTime.UtcNow };
            _subject = new Subject { SubjectName = "Mathematics", SubjectCategory = "Advanced" };
            _tests = new List<Test> 
                                    { 
                                      new Test 
                                                { 
                                                    TestId = 1, 
                                                    DateOfCreation = DateTime.UtcNow, 
                                                    Subject = _subject,
<<<<<<< HEAD
                                                    Creator = _user,
                                                    Questions = _questions 
=======
                                                    Creator = _user
>>>>>>>  This is a combination of 5 commits.
                                                },
                                      new Test 
                                                { 
                                                    TestId = 2, 
                                                    DateOfCreation = DateTime.UtcNow, 
                                                    Subject = _subject,
<<<<<<< HEAD
                                                    Creator = _user, 
                                                    Questions = _questions 
=======
                                                    Creator = _user
>>>>>>>  This is a combination of 5 commits.
                                                }
                                    };
            MockRepository.Setup(_ => _.Query()).Returns(_tests.AsQueryable());
            _test = new Test 
                            { 
                               TestId = 3, 
                               DateOfCreation = DateTime.UtcNow, 
                               Subject = _subject, 
<<<<<<< HEAD
                               Creator = _user, 
                               Questions = _questions 
=======
                               Creator = _user                               
>>>>>>>  This is a combination of 5 commits.
                            };
            MockRepository.Setup(_ => _.Add(_test)).Returns(_test);
            _repository = MockRepository.Object;
            _service = new TestService(_repository, _unitOfWork);
            MockRepository.Setup(_ => _.Query()).Returns(_tests.AsQueryable());
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
            _tests = null;
            _questions = null;
            _unitOfWork = null;
            MockRepository = null; 
        }

        [Test]
        [Category("TestService")]
        [Description("Checks if the GetTest method with Id as parameter is working correctly.")]
        [TestCase(1)]
        [TestCase(2)]
        public void GetTestCheck(int testId)
        {                      
            var result = _service.GetTest(testId);
<<<<<<< HEAD
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.First().Questions.Count());
=======
            Assert.IsNotNull(result);           
>>>>>>>  This is a combination of 5 commits.
        }

        [Test]
        [Category("TestService")]
        [Description("Checks if the GetTestCreatedByUser is working correctly.")]
        public void GetTestsCreatedByUserCheck()
        {
            var result = _service.GetTestsCreatedByUser(_user);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        [Category("TestService")]
        [Description("Checks if the GetTestsBySubject is working correctly.")]
        public void GetTestsBySubjectCheck()
        {
            var result = _service.GetTestsBySubject(_subject);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        [Category("TestService")]
        [Description("Checks if the CreateNewTest works corectly")]
        public void CreateNewTestCheck()
        {
            var result = _service.CreateNewTest(_test);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Test>(result);            
        }
    }
}