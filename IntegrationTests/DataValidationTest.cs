using EFRepository.Context;
using EFRepository.Infrastructure;
using NUnit.Framework;
using ParikshaModel.Model;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using ParikshaModel.Model.User;

namespace IntegrationTests
{
    [TestFixture]
    public class DataValidationTest
    {
        public ParikshaContext Context { get; set; }

        public IRepository<UserDetail> UserRepository { get; set; }

        public IRepository<Subject> SubjectRepository { get; set; }
        
        public IRepository<Standard> StandardRepository { get; set; }
        
        public IUnitOfWork EfUnitOfWork { get; set; }

        [SetUp]
        public void Initialise()
        {
            Context = new ParikshaContext();
            EfUnitOfWork = new EFUnitOfWork(Context);
            UserRepository = new EFRepository<UserDetail>(EfUnitOfWork, Context);
            SubjectRepository = new EFRepository<Subject>(EfUnitOfWork, Context);
            StandardRepository = new EFRepository<Standard>(EfUnitOfWork, Context);
        }

        [TearDown]
        public void CleanUp()
        {
            Context = null;
            EfUnitOfWork = null;
            UserRepository = null;
            SubjectRepository = null;
            StandardRepository = null;
        }

        [Test]
        [Category("DataValidationTestForUser")]
        [Description("UserName can be maximum of length 10")]
        [TestCase("MegaUserNamePreparedForFailure")]
        [TestCase("SomethingGreater")]        
        public void CheckUserNameLengthForException(string userName)
        {
            var user = new UserDetail
             {
                Name = userName,
                Password = "FooPassword",
                DateOfCreation = DateTime.UtcNow,
                UserRole = UserRole.Principal                                        
              };
            
            UserRepository.Add(user);
            Assert.Throws<DbEntityValidationException>(() => EfUnitOfWork.Commit());
        }

        [Test]
        [Category("DataValidationTestForUser")]
        [Description("UserName can be maximum of length 10")]
        [TestCase("Shakira")]
        [TestCase("Beyonce")]
        public void CheckUserNameLengthForValidCases(string userName)
        {
            var user = new UserDetail
            {
                Name = userName,
                Password = "FooPassword",
                DateOfCreation = DateTime.UtcNow,
                UserRole = UserRole.Principal
            };
            var result = UserRepository.Add(user);
           
            Assert.DoesNotThrow(() => EfUnitOfWork.Commit());
            Assert.AreEqual(userName, result.Name);
        }
               
        [Test]
        [Category("DataValidationTestForSubject")]
        [Description("SubjectName must be of Maximum length of 15")]
        [TestCase("AwesomeSubject")]
        [TestCase("AwesomeSubjects")]
        public void CheckSubjectNameLengthfForValidCases(string subjectName)
        {
            var standard = StandardRepository.Query().FirstOrDefault();
            var subject = new Subject 
                                    {
                                        SubjectName = subjectName,
                                        SubjectCategory = "MyAwesomeSubjectCategory",
                                        Standard = standard
                                    };
            var result = SubjectRepository.Add(subject);
            Assert.DoesNotThrow(() => EfUnitOfWork.Commit());
        }

        [Test]
        [Category("DataValidationTestForSubject")]
        [Description("SubjectName must be of Maximum length of 15")]
        [TestCase("AwesomeSubjectMoreThanFifteen")]        
        public void CheckSubjectNameLengthfForInValidCases(string subjectName)
        {
            var standard = StandardRepository.Query().FirstOrDefault();
            var subject = new Subject
                                    {
                                        SubjectName = subjectName,
                                        SubjectCategory = "MyAwesomeSubjectCategory",
                                        Standard = standard
                                    };
            var result = SubjectRepository.Add(subject);
            Assert.Throws<DbEntityValidationException>(() => EfUnitOfWork.Commit());
        }

        [Test]
        [Category("DataValidationTestForStandard")]
        [Description("If a Subject is created without a Standard an exception must be thrown.")]
        public void CheckIfSubjectCanBeCreatedWithoutAStandard()
        {            
            var subject = new Subject
                                    {
                                        SubjectName = "AwesomeSubject",
                                        SubjectCategory = "MyAwesomeSubjectCategory"
                                    };
            var result = SubjectRepository.Add(subject);
            Assert.Throws<DbUpdateException>(
                                                () => EfUnitOfWork.Commit());
        }
    }
}