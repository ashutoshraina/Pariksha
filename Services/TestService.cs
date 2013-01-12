using System;
using System.Collections.Generic;
using System.Linq;
using ParikshaModel.Model;
using EFRepository.Infrastructure;
namespace ParikshaServices
{
    public class TestService
    {
        private IRepository<Test> _testrepository;
        private IUnitOfWork _unitofwork;

        public TestService(IRepository<Test> testRepository, IUnitOfWork unitOfWork)
        {
            _testrepository = testRepository;
            _unitofwork = unitOfWork;
        }

        public void CreateNewTest(ICollection<Question> questionIds, UserDetail creator , Subject subject)
        {
            Test test = new Test();
            test.Creator = creator;
            test.DateOfCreation = DateTime.UtcNow;
            test.Subject = subject;
            test.Questions = questionIds;
            _testrepository.Add(test);
            _unitofwork.Commit();
        }

        public IQueryable<Test> GetTest(int testId)
        {
            return _testrepository.QueryWithInclude("Questions").Where(_ => _.TestId == testId);
        }
        
        public IQueryable<Test> GetTestsCreatedByUser(UserDetail user)
        {
            return _testrepository.Query().Where(_ => _.Creator == user);
        }

        public IQueryable<Test> GetTestsBySubject(Subject subject)
        {
            return _testrepository.Query().Where(_ => _.Subject == subject);
        }
    }
}