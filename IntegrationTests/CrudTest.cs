using EFRepository.Context;
using EFRepository.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParikshaModel.Model;
using System;
using System.Linq;
using FluentAssertions;
namespace IntegrationTests
{
    [TestClass]
    public class CrudTest
    {
        public TestContext TextContext { get; set; }
        public EFUnitOfWork EfUoW { get; set; }
        public ParikshaContext Context { get; set; }
        public EFRepository<UserDetail> UserRepository { get; set; }
        public EFRepository<Standard> StandardRepository {get;set;}
        public EFRepository<Subject> SubjectRepository {get;set;}
        public EFRepository<Question> QuestionRepository {get;set;}
        public UserDetail User { get; set; }

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            Context = new ParikshaContext();
            EfUoW = new EFUnitOfWork(Context);
            UserRepository = new EFRepository<UserDetail>(EfUoW,Context);
            QuestionRepository = new EFRepository<Question>(EfUoW, Context);
            StandardRepository = new EFRepository<Standard>(EfUoW,Context);
            SubjectRepository = new EFRepository<Subject>(EfUoW, Context);
            User = new UserDetail { UserRole = "Smart Ass", Password = "Pwd", Name = "ashutosh", DateOfCreation = DateTime.Now };
            UserRepository.Add(User);
            EfUoW.Commit();
        }

        /// <summary>
        ///Cleanup() is called once during test execution after test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Context.Database.ExecuteSqlCommand("delete from ParikshaDev.Users");
            EfUoW.Dispose();            
        }
        
        [TestClass]
        public class UserDetailTest : CrudTest
        {        

                [TestMethod]
                [TestCategory("CRUDTestForUser")]
                public void Create()
                {
                    User = new UserDetail { UserRole = "Admin", Password = "Pwd", Name = "awesome", DateOfCreation = DateTime.Now };    
                    var initialCount = UserRepository.Query().Count();
                    UserRepository.Add(User);
                    EfUoW.Commit();
                    var result = UserRepository.Query().Count();
                    Assert.AreEqual(initialCount + 1 , result);
                }

                [TestMethod]
                [TestCategory("CRUDTestForUser")]
                public void Retrieve()
                {
                   var result = UserRepository.Query().Where(_ => _.Name.Equals("ashutosh"));
                   var type = result.FirstOrDefault().GetType();
                   var role = result.FirstOrDefault().UserRole;
                   bool IsCountGreaterThanZero = false;
                   if (result.Count() > 0)
                       IsCountGreaterThanZero = true;
                   Assert.AreEqual(typeof(UserDetail), type);
                   Assert.AreEqual(true,IsCountGreaterThanZero);
                   Assert.AreEqual("Smart Ass", role);
                }

                [TestMethod]
                [TestCategory("CRUDTestForUser")]
                public void Update()
                {
                    UserRepository.Query().Where(_ => _.Name.Equals("ashutosh")).FirstOrDefault().UserRole = "Awesome Role";
                    EfUoW.Commit();
                    var result = UserRepository.Query().Where(_ => _.Name.Equals("ashutosh")).FirstOrDefault();
                    Assert.IsNotNull(result);
                    Assert.AreEqual("Awesome Role", result.UserRole);
                }

                [TestMethod]
                [TestCategory("CRUDTestForUser")]
                public void Delete()
                {
                    var user = UserRepository.Query().Where(_ => _.Name.Equals("ashutosh")).FirstOrDefault();
                    UserRepository.Remove(user);
                    EfUoW.Commit();
                    var result = UserRepository.Query().Where(_ => _.Name.Equals("ashutosh")).Count();
                    Assert.IsNotNull(result);
                    Assert.AreEqual(0,result);
                }  
        }

         [TestClass]
        public class QuestionTest : CrudTest
        {

                [TestMethod]
                [TestCategory("CRUDTestForQuestion")]
                public void Create()
                {
                    var question = new Brief {QuestionText = "I am a brief question",Rating = 4 , Short = true, Difficulty = Difficulty.Hard, Answer = "No real question", DateOfCreation = DateTime.UtcNow };
                    var brief = QuestionRepository.Add(question);
                    EfUoW.Commit();
                    var result = QuestionRepository.Query().OfType<Brief>().Where(_ => _.QuestionId == brief.QuestionId).SingleOrDefault();
                    Assert.IsNotNull(brief);
                    Assert.AreEqual("I am a brief question", result.QuestionText);
                }

                [TestMethod]
                [TestCategory("CRUDTestForQuestion")]
                public void Retrieve()
                {
                    var question = QuestionRepository.Query().OfType<Brief>().Where(_ => _.Rating > 3).FirstOrDefault();
                    Assert.IsNotNull(question);
                    Assert.IsInstanceOfType(question,typeof(Brief));
                    Assert.AreEqual(true,question.Short);
                }

                [TestMethod]
                [TestCategory("CRUDTestForQuestion")]
                public void Update()
                {
                    var question = QuestionRepository.Query().OfType<Brief>().Where(_ => _.Rating > 3).FirstOrDefault();
                    question.Answer = "I have changed the answer";
                    var result =  QuestionRepository.Update(question);
                    EfUoW.Commit();
                    Assert.IsNotNull(result);
                    Assert.IsInstanceOfType(result, typeof(Brief));
                    Assert.AreEqual("I have changed the answer", (result as Brief).Answer);
                }

                [TestMethod]
                [TestCategory("CRUDTestForQuestion")]
                public void Delete()
                {
                    var question = QuestionRepository.Query().FirstOrDefault();
                    QuestionRepository.Remove(question);
                    EfUoW.Commit();
                    var result = QuestionRepository.Query().Where(_ => _.QuestionId == question.QuestionId).Count();
                    Assert.AreEqual(0,result);
                }          
        }

         [TestClass]
        public class StandardTest : CrudTest
        {
                [TestMethod]
                [TestCategory("CRUDTestForStandard")]
                public void Create()
                {
                    var standard = new Standard{StandardName = "First"};
                    var result = StandardRepository.Add(standard);
                    EfUoW.Commit();
                    Assert.IsNotNull(result);
                    Assert.AreEqual("First",result.StandardName);
                }

                [TestMethod]
                [TestCategory("CRUDTestForStandard")]
                public void Retrieve()
                {
                    var result = StandardRepository.Query().Where(_ => _.StandardName.Equals("First"));
                    Assert.IsNotNull(result);                    
                }

                [TestMethod]
                [TestCategory("CRUDTestForStandard")]
                public void Update()
                {
                    var subject = new Subject{SubjectName = "Mathematics",SubjectCategory = "Addition"};
                    var result = StandardRepository.Query().FirstOrDefault();                    
                    result.StandardName = "FooBaar";
                    var initialCount = result.Subjects.Count();
                    result.Subjects.Add(subject);

                    EfUoW.Commit();

                    var subjectName = StandardRepository.Query().FirstOrDefault().StandardName;
                    Assert.AreEqual("FooBaar",subjectName);
                    Assert.AreEqual((initialCount + 1),result.Subjects.Count());
                    Assert.AreEqual(true,result.Subjects.Contains(subject));
                }

                [TestMethod]
                [TestCategory("CRUDTestForStandard")]
                public void Delete()
                {
                    var standard = new Standard{StandardName = "Second"};
                    var subjectAdded = StandardRepository.Add(standard);
                    EfUoW.Commit();
                    StandardRepository.Remove(subjectAdded);
                    EfUoW.Commit();
                    var result = StandardRepository.Query().Where(_ => _.StandardId == subjectAdded.StandardId).Count();
                    Assert.IsNotNull(result);
                    Assert.AreEqual(0,result);
                }        
         }

         [TestClass]
        public class SubjectTest : CrudTest
        {

                [TestMethod]
                [TestCategory("CRUDTestForSubject")]
                public void Create()
                { 
          
                }

                [TestMethod]
                [TestCategory("CRUDTestForSubject")]
                public void Retrieve()
                {
           
                }

                [TestMethod]
                [TestCategory("CRUDTestForSubject")]
                public void Update()
                {
       
                }

                [TestMethod]
                [TestCategory("CRUDTestForSubject")]
                public void Delete()
                {
       
                }
        }
    }
}