using EFRepository.Context;
using EFRepository.Infrastructure;
using ParikshaModel.Model;
using System;
using System.Linq;
using NUnit.Framework;
using ParikshaModel.Model.User;

namespace IntegrationTests
{
    [TestFixture]
    public class CrudTest
    {
        public TestContext TextContext { get; set; }
        
        public EFUnitOfWork EfUoW { get; set; }
        
        public ParikshaContext Context { get; set; }
        
        public EFRepository<UserDetail> UserRepository { get; set; }
        
        public EFRepository<Standard> StandardRepository { get; set; }
        
        public EFRepository<Subject> SubjectRepository { get; set; }
        
        public EFRepository<Question> QuestionRepository { get; set; }
        
        public UserDetail User { get; set; }
        
        public Subject Subject { get; set; }
        
        public Standard Standard { get; set; }        

        /// <summary>
        /// Initialize() is called once during test execution before
        /// test methods in test class are executed.
        /// </summary>
        [TestFixtureSetUp]
        public void Initialize()
        {
            Context = new ParikshaContext();
            EfUoW = new EFUnitOfWork(Context);
            UserRepository = new EFRepository<UserDetail>(EfUoW, Context);
            QuestionRepository = new EFRepository<Question>(EfUoW, Context);
            StandardRepository = new EFRepository<Standard>(EfUoW, Context);
            SubjectRepository = new EFRepository<Subject>(EfUoW, Context);
            User = new UserDetail { UserRole = UserRole.Admin, Password = "Pwd", Name = "ashutosh", DateOfCreation = DateTime.UtcNow };
            Standard = new Standard { StandardName = "First" };
            Subject = new Subject { SubjectName = "Mathematics", SubjectCategory = "Algebra", Standard = Standard };
            UserRepository.Add(User);
            StandardRepository.Add(Standard);
            SubjectRepository.Add(Subject);
            EfUoW.Commit();
        }

        /// <summary>
        /// Cleanup() is called once during test execution after test methods in class have executed unless
        /// test class' Initialize() method throws an exception.
        /// </summary>
        [TestFixtureTearDown]
        public void Cleanup()
        {
            // Context.Database.ExecuteSqlCommand("delete from ParikshaDev.Users");
            EfUoW.Dispose();            
        }

        [TestFixture]
        public class UserDetailTest : CrudTest
        {     
            [Test]
            [Category("CRUDTestForUser")]
            public void Create()
            {
                User = new UserDetail 
                                    { 
                                        UserRole = UserRole.Admin, 
                                        Password = "MySuperAwesomePasswordThatYouWillNotBeAbleToCrack", 
                                        Name = "awesome", 
                                        DateOfCreation = DateTime.UtcNow 
                                    };    
                var initialCount = UserRepository.Query().Count();
                UserRepository.Add(User);
                EfUoW.Commit();
                var result = UserRepository.Query().Count();
                Assert.AreEqual(initialCount + 1, result);
            }

            [Test]
            [Category("CRUDTestForUser")]
            public void Retrieve()
            {
                var userName = "ashutosh";
                var result = UserRepository.Query().Where(_ => _.Name.Equals(userName));
                
                Assert.IsNotNull(result);
                bool isCountGreaterThanZero = result.Any();

                Assert.AreEqual(true, isCountGreaterThanZero);
                Assert.AreEqual(userName, result.FirstOrDefault().Name);
            }

            [Test]
            [Category("CRUDTestForUser")]
            public void Update()
            {
                var user = UserRepository.Query().FirstOrDefault();
                user.Password = "SomeAwesomePassword";
                var result = UserRepository.Update(user);
                EfUoW.Commit();
                    
                Assert.IsNotNull(result);
                Assert.AreEqual("SomeAwesomePassword", result.Password);
            }

            [Test]
            [Ignore]
            [Category("CRUDTestForUser")]
            public void Delete()
            {
                var user = UserRepository.Query().FirstOrDefault();
                UserRepository.Remove(user);
                EfUoW.Commit();
                var result = UserRepository.Query()
                                            .Where(_ => _.UserDetailId == user.UserDetailId)
                                            .FirstOrDefault();
                Assert.IsNull(result);
            }
        }

        [TestFixture]
        public class QuestionTest : CrudTest
        {
            private static Brief BriefQuestionToBeCreated { get; set; }

            private static Match MatchQuestionToBeCreated { get; set; }

            [TestFixtureSetUp]
            public void Initialise()
            {
                BriefQuestionToBeCreated = new Brief
                {
                    QuestionText = "I am a brief question",
                    Rating = 4,
                    Short = true,
                    Difficulty = Difficulty.Hard,
                    Answer = "No real question",
                    Creator = User,
                    Subject = Subject,
                    DateOfCreation = DateTime.UtcNow
                };

                MatchQuestionToBeCreated = new Match
                {
                    QuestionText = "I am a brief question",
                    Rating = 4,
                    LeftChoices = "foo;baar;temp;help",
                    Difficulty = Difficulty.Hard,
                    RightChoices = "foo;baar;temp;help",
                    Creator = User,
                    Subject = Subject,
                    DateOfCreation = DateTime.UtcNow
                };                   
            }

                [Test]
                [Category("CRUDTestForQuestion")]                
                public void CreateBrief()
                {
                    var brief = QuestionRepository.Add(BriefQuestionToBeCreated);
                    EfUoW.Commit();
                    var result = QuestionRepository.Query().OfType<Brief>().Where(_ => _.QuestionId == brief.QuestionId).SingleOrDefault();
                    Assert.IsNotNull(brief);
                    Assert.AreEqual("I am a brief question", result.QuestionText);
                }

                [Test]
                [Category("CRUDTestForQuestion")]
                public void CreateMatch()
                {
                    var match = QuestionRepository.Add(MatchQuestionToBeCreated);
                    EfUoW.Commit();
                    var result = QuestionRepository.Query().OfType<Match>().Where(_ => _.QuestionId == match.QuestionId).SingleOrDefault();
                    Assert.IsNotNull(match);
                    Assert.AreEqual("I am a brief question", result.QuestionText);
                }

                [Test]
                [Category("CRUDTestForQuestion")]
                public void Retrieve()
                {
                    var questionToAdd = new Brief 
                                                  { 
                                                    QuestionText = "I am a brief question", 
                                                    Rating = 4, Short = true, 
                                                    Difficulty = Difficulty.Hard, 
                                                    Answer = "No real question", 
                                                    Creator = User, 
                                                    Subject = Subject, 
                                                    DateOfCreation = DateTime.UtcNow 
                                                  };
                    var brief = QuestionRepository.Add(questionToAdd);
                    EfUoW.Commit();

                    var result = QuestionRepository.Query().OfType<Brief>().FirstOrDefault();
                    Assert.IsNotNull(result);
                    Assert.IsInstanceOf<Brief>(result);
                    Assert.AreEqual(true, result.Short);
                }

                [Test]
                [Category("CRUDTestForQuestion")]
                public void Update()
                {
                    var questionToAdd = new Brief 
                                                { 
                                                    QuestionText = "I am a brief question", 
                                                    Rating = 4, 
                                                    Short = true, 
                                                    Difficulty = Difficulty.Hard, 
                                                    Answer = "No real question", 
                                                    Creator = User, 
                                                    Subject = Subject, 
                                                    DateOfCreation = DateTime.UtcNow 
                                                };
                    var brief = QuestionRepository.Add(questionToAdd);
                    EfUoW.Commit();

                    var question = QuestionRepository.Query().OfType<Brief>().Where(_ => _.Rating > 3).FirstOrDefault();
                    question.Answer = "I have changed the answer";
                    var result = QuestionRepository.Update(question);
                    EfUoW.Commit();

                    Assert.IsNotNull(result);
                    Assert.IsInstanceOf<Brief>(result);
                    Assert.AreEqual("I have changed the answer", (result as Brief).Answer);
                }

                [Test]
                [Category("CRUDTestForQuestion")]
                public void Delete()
                {
                    var question = QuestionRepository.Query().FirstOrDefault();
                    QuestionRepository.Remove(question);
                    EfUoW.Commit();
                    var result = QuestionRepository.Query().Count(_ => _.QuestionId == question.QuestionId);
                    Assert.AreEqual(0, result);
                }          
        }

        [TestFixture]
        public class StandardTest : CrudTest
        {
                [Test]
                [Category("CRUDTestForStandard")]
                public void Create()
                {
                    var standard = new Standard { StandardName = "First" };
                    var result = StandardRepository.Add(standard);
                    EfUoW.Commit();
                    Assert.IsNotNull(result);
                    Assert.AreEqual("First", result.StandardName);
                }

                [Test]
                [Category("CRUDTestForStandard")]
                public void Retrieve()
                {
                    var result = StandardRepository.Query().Where(_ => _.StandardName.Equals("First"));
                    Assert.IsNotNull(result);                    
                }

                [Test]
                [Category("CRUDTestForStandard")]
                public void Update()
                {
                    var standard = StandardRepository.Query().FirstOrDefault();
                    var subject = new Subject { SubjectName = "Mathematics", SubjectCategory = "Addition", Standard = standard };
                    standard.StandardName = "FooBaar";
                    var initialCount = standard.Subjects.Count();
                    standard.Subjects.Add(subject);

                    EfUoW.Commit();

                    var result = StandardRepository.Query().FirstOrDefault();
                    var standardName = result.StandardName;
                    Assert.AreEqual("FooBaar", standardName);
                    Assert.AreEqual(initialCount + 1, result.Subjects.Count());
                }

                [Test]
                [Category("CRUDTestForStandard")]
                public void Delete()
                {
                    var standard = new Standard { StandardName = "Second" };
                    var subjectAdded = StandardRepository.Add(standard);
                    EfUoW.Commit();
                    StandardRepository.Remove(subjectAdded);
                    EfUoW.Commit();
                    var result = StandardRepository.Query().Count(_ => _.StandardId == subjectAdded.StandardId);
                    Assert.IsNotNull(result);
                    Assert.AreEqual(0, result);
                }        
         }

        [TestFixture]
        public class SubjectTest : CrudTest
        {
                [Test]
                [Category("CRUDTestForSubject")]
                public void Create()
                {
                    var initialCount = SubjectRepository.Query().Count();
                    var standard = StandardRepository.Query().FirstOrDefault();
                    var subject = new Subject { SubjectName = "DataStructures", SubjectCategory = "Advanced", Standard = standard };
                    SubjectRepository.Add(subject);                    
                    EfUoW.Commit();

                    var finalCount = SubjectRepository.Query().Count();
                    var result = SubjectRepository.Query().Where(_ => _.SubjectName.Equals("DataStructures")).FirstOrDefault();

                    Assert.AreEqual(initialCount + 1, finalCount);
                    Assert.IsNotNull(result);
                    Assert.AreEqual("Advanced", result.SubjectCategory);
                }

                [Test]
                [Category("CRUDTestForSubject")]
                public void Retrieve()
                {
                    var result = SubjectRepository.Query().Where(_ => _.SubjectName.Equals("DataStructures")).FirstOrDefault();                    
                    Assert.IsNotNull(result);
                    Assert.AreEqual("Advanced", result.SubjectCategory);           
                }

                [Test]
                [Category("CRUDTestForSubject")]
                public void Update()
                {
                    var initialCount = SubjectRepository.Query().Count();
                    var standard = StandardRepository.Query().FirstOrDefault();
                    var subject = new Subject { SubjectName = "Algorithms", SubjectCategory = "Advanced", Standard = standard };
                    SubjectRepository.Add(subject);
                    EfUoW.Commit();

                    var result = SubjectRepository.Query().Where(_ => _.SubjectName.Equals("Algorithms")).FirstOrDefault();
                    result.SubjectCategory = "SuperAdvanced";
                    SubjectRepository.Update(result);
                    EfUoW.Commit();

                    Assert.IsNotNull(result);
                    Assert.AreEqual("SuperAdvanced", result.SubjectCategory);
                }

                [Test]
                [Category("CRUDTestForSubject")]
                public void Delete()
                {                    
                    var standard = StandardRepository.Query().FirstOrDefault();
                    var subject = new Subject { SubjectName = "Algorithms", SubjectCategory = "Beginner", Standard = standard };
                    SubjectRepository.Add(subject);
                    EfUoW.Commit();

                    var initialCount = SubjectRepository.Query().Count();
                    var toDelete = SubjectRepository.Query().Where(_ => _.SubjectCategory.Equals("Beginner")).FirstOrDefault();
                    var result = SubjectRepository.Remove(toDelete);
                    EfUoW.Commit();
                    var finalCount = SubjectRepository.Query().Count();

                    Assert.IsNotNull(result);
                    Assert.AreEqual(initialCount - 1, finalCount);
                }
        }
    }
}