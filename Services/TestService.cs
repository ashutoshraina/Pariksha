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

        public void CreateNewTest()
        {
        }

        public void CreateNewTest(IList<int> questionId)
        { 
        
        }

        public void GetTestWithQuestions(int TestId)
        {
 
        }

        public void GetTest(int TestId)
        { 
        }

        public void GetTestsCreatedByUser(int UserId)
        {

        }

    }
}
