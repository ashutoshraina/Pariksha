using EFRepository.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParikshaModel.Model;
using ParikshaServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParikshaModelTests
{
    [TestClass]
    public class QuestionServiceTest
    {
        private static IRepository<Question> repository;
        private static QuestionService service;
        private static List<Question> questions;
        private static IUnitOfWork UnitOfWork;
        public TestContext TextContext { get; set; }
        Mock<IRepository<Question>> mockrepository = new Mock<IRepository<Question>>();

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            var entity = new Question  { QuestionId = 1,Difficulty = Difficulty.Hard, Rating = 5};
            var entity2 = new Question { QuestionId = 2, Difficulty = Difficulty.Hard, Rating = 3};
            questions = new List<Question> { entity ,entity2};

            
            mockrepository.Setup(_ => _.Query()).Returns(questions.AsQueryable());
            
            repository = mockrepository.Object;
            service = new QuestionService(repository,UnitOfWork);   
        }

        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TestCleanup()]
        public void Cleanup()
        {

            //  TODO: Add test cleanup code
        }

        [TestMethod]
        [TestCategory("QuestionService")]
        [Description("This test checks if the ModifyRating method works correctly")]
        public void RatingChangeCheck()
        {                 
            var newrating = 4;
            service.ModifyQuestionRating(1, newrating);
            Assert.AreEqual(4,repository.Query().Where(_ => _.QuestionId == 1).SingleOrDefault().Rating);
        }

        [TestMethod]
        [TestCategory("QuestionService")]
        [Description("This test checks if the ModifyDifficulty method works correctly")]
        public void DifficultyChangeCheck()
        {
            //var newDifficulty = Difficulty.Difficult;
            service.ModifyQuestionDifficulty(1, Difficulty.Difficult);
            Assert.AreEqual(Difficulty.Difficult, repository.Query().Where(_ => _.QuestionId == 1).SingleOrDefault().Difficulty);
        }        

        [TestMethod]
        [TestCategory("QuestionService")]
        [Description("This test checks if the Add Question method works correctly")]
        public void AddQuestionCheck()
        {
            var question = new Question {QuestionId = 3,Difficulty = Difficulty.Hard,Rating = 5};
            mockrepository.Setup(_ => _.Add(question)).Returns(question);
            var result = service.AddQuestion(question);
            Assert.AreEqual(5, result.Rating);
        }

        [TestMethod]
        [TestCategory("QuestionService")]
        [Description("This test checks if the Add Question method works correctly for Brief")]
        public void AddQuestionCheckBrief()
        {
            var question = new Brief { QuestionId = 4, Difficulty = Difficulty.Hard, Rating = 5, QuestionText = "Who let the dog's out ?",Answer = "It wasn't me"};
            mockrepository.Setup(_ => _.Add(question)).Returns(question);
            var result = service.AddQuestion(question);
            Assert.AreEqual(5, result.Rating);
        }
    }
}