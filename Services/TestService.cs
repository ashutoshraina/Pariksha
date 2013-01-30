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

        public Test CreateNewTest(Test test)
        {
            return _testrepository.Add(test);            
        }

        public IQueryable<Test> GetTest(int testId)
        {
            return _testrepository.Query().Where(_ => _.TestId == testId);
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