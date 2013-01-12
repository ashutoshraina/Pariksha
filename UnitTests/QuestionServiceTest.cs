using EFRepository.Infrastructure;
using Moq;
using ParikshaModel.Model;
using ParikshaServices;
using System.Collections.Generic;
using System.Linq;
using NUnit;
using NUnit.Framework;
namespace UnitTests
{
    [TestFixture]
    public class QuestionServiceTest
    {
        private static IRepository<Question> repository;
        private static QuestionService service;
        private static IList<Question> questions;
        private static IUnitOfWork UnitOfWork;
        public TestContext TextContext { get; set; }
        Mock<IRepository<Question>> mockrepository; 

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [SetUp()]
        public void Initialize()
        {
            mockrepository = new Mock<IRepository<Question>>();
            var firstQuestion = new Question  { QuestionId = 1,Difficulty = Difficulty.Hard, Rating = 5};
            var secondQuestion = new Question { QuestionId = 2, Difficulty = Difficulty.Hard, Rating = 3};
            questions = new List<Question> { firstQuestion, secondQuestion };
                        
            mockrepository.Setup(_ => _.Query()).Returns(questions.AsQueryable());
            
            repository = mockrepository.Object;
            service = new QuestionService(repository,UnitOfWork);   
        }

        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TearDown()]
        public void Cleanup()
        {
            repository = null;
            service = null;
            questions = null;
            UnitOfWork = null;
            mockrepository = null;
            //  TODO: Add test cleanup code
        }

        [Test]
        [Category("QuestionServiceTests")]
        [Description("This test checks if the ModifyRating method works correctly")]
        public void RatingChangeCheck()
        {                 
            var newrating = 4;
            service.ModifyQuestionRating(1, newrating);
            Assert.AreEqual(4,repository.Query().Where(_ => _.QuestionId == 1).SingleOrDefault().Rating);
        }

        [Test]
        [Category("QuestionServiceTests")]
        [Description("This test checks if the ModifyDifficulty method works correctly")]
        public void DifficultyChangeCheck()
        {
            service.ModifyQuestionDifficulty(1, Difficulty.Difficult);
            Assert.AreEqual(Difficulty.Difficult, repository.Query().Where(_ => _.QuestionId == 1).SingleOrDefault().Difficulty);
        }        

        [Test]
        [Category("QuestionServiceTests")]
        [Description("This test checks if the Add Question method works correctly")]
        public void AddQuestionCheck()
        {
            var question = new Question {QuestionId = 3,Difficulty = Difficulty.Hard,Rating = 5};
            mockrepository.Setup(_ => _.Add(question)).Returns(question);
            var result = service.AddQuestion(question);
            Assert.AreEqual(5, result.Rating);
        }

        [Test]
        [Category("QuestionServiceTests")]
        [Description("This test checks if the Add Question method works correctly for Brief")]
        public void AddQuestionCheckForBrief()
        {
            var question = new Brief { QuestionId = 4, Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?",Answer = "It wasn't me"};
            mockrepository.Setup(_ => _.Add(question)).Returns(question);
            var result = service.AddQuestion(question);
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Rating);
        }

        [Test]
        [Category("QuestionServiceTests")]
        [Description("This test checks if the RemoveQuestion method works correctly")]
        public void RemoveQuestion()
        {
            var question = new Brief { QuestionId = 4, Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?", Answer = "It wasn't me" };
            mockrepository.Setup(_ => _.Remove(question)).Returns(question);
            var result = service.RemoveQuestion(question);
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Rating);
        }
    }
}