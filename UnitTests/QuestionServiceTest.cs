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
    public class QuestionServiceTest
    {
        private IRepository<Question> _repository;

        private QuestionService _service;
        
        private IEnumerable<Question> _questions;
        
        private IUnitOfWork _unitOfWork;

        private Mock<IRepository<Question>> _mockRepository;

        /// <summary>
        /// Initialize() is called once during test execution before
        /// test methods in test class are executed.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialize()
        {
            _mockRepository = new Mock<IRepository<Question>>();
            var firstQuestion = new Question { QuestionId = 1, Difficulty = Difficulty.Hard, Rating = 5 };
            var secondQuestion = new Question { QuestionId = 2, Difficulty = Difficulty.Hard, Rating = 3 };
            var brief = new Brief { Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?", Answer = "It wasn't me" };
            var choice = new Choice { Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?", Choices = "Me,You,All of us all are the culprits", Answers = "All of us all are the culprits", IsMultiplechoice = true };
            _questions = new List<Question> { firstQuestion, secondQuestion, brief, choice };
                        
            _mockRepository.Setup(_ => _.Query()).Returns(_questions.AsQueryable());
            
            _repository = _mockRepository.Object;
            _service = new QuestionService(_repository, _unitOfWork);   
        }

        /// <summary>
        /// Cleanup() is called once during test execution after
        /// test methods in class have executed unless
        /// test class' Initialize() method throws an exception.
        /// </summary>
        [TestFixtureTearDown]
        public void Cleanup()
        {
            _repository = null;
            _service = null;
            _questions = null;
            _unitOfWork = null;
            _mockRepository = null;
        }

        [Test]
        [Category("QuestionService")]
        [Description("Test checks if the ModifyRating method works correctly")]
        public void RatingChangeCheck()
        {                 
            var newrating = 4;
            _service.ModifyQuestionRating(1, newrating);
            Assert.AreEqual(4, _repository.Query().SingleOrDefault(_ => _.QuestionId == 1).Rating);
        }

        [Test]
        [Category("QuestionService")]
        [Description("Test checks if the ModifyDifficulty method works correctly")]
        public void DifficultyChangeCheck()
        {
            _service.ModifyQuestionDifficulty(1, Difficulty.Difficult);
            Assert.AreEqual(Difficulty.Difficult, _repository.Query().Where(_ => _.QuestionId == 1).SingleOrDefault().Difficulty);
        }        

        [Test]
        [Category("QuestionService")]
        [Description("Test checks if the Add Question method works correctly")]
        public void AddQuestionCheck()
        {
            var question = new Question { Difficulty = Difficulty.Difficult, Rating = 5 };
            _mockRepository.Setup(_ => _.Add(question)).Returns(question);
            var result = _service.AddQuestion(question);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Rating);
        }

        [Test]
        [Category("QuestionService")]
        [Description("Test checks if the Add Question method works correctly for Brief")]
        public void AddQuestionBriefCheck()
        {
            var question = new Brief { Difficulty = Difficulty.Hard, Rating = 4, QuestionText = "Who let the dog's out ?", Answer = "It wasn't me" };
            _mockRepository.Setup(_ => _.Add(question)).Returns(question);
            var result = _service.AddQuestion(question);

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Rating);
        }

        [Test]
        [Category("QuestionService")]
        [Description("Test checks if the RemoveQuestion method works correctly")]
        public void RemoveQuestionCheck()
        {
            var question = new Brief { QuestionId = 4, Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?", Answer = "It wasn't me" };
            _mockRepository.Setup(_ => _.Remove(question)).Returns(question);
            var result = _service.RemoveQuestion(question);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Rating);
        }

        [Test]
        [Category("QuestionService")]
        [Description("Test checks if the GetQuestionsByType method works correctly")]
        [TestCase(typeof(Brief))]
        [TestCase(typeof(ParikshaModel.Model.Match))]
        [TestCase(typeof(Choice))]
        [TestCase(typeof(Custom))]
        public void GetQuestionsByTypeCheck(Type questionType)
        {
            var result = _service.GetAllQuestionsByType(questionType);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IQueryable<Question>>(result);
        }
    }
}