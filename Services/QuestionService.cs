using EFRepository.Infrastructure;
using EFRepository.Context;
using ParikshaModel.Model;
using System;
using System.Linq;
namespace ParikshaServices
{
    public class QuestionService
    {
        private IRepository<Question> _questionrepository;
        private IUnitOfWork _unitofwork;

        public QuestionService(IRepository<Question> Repository, IUnitOfWork UnitOfWork)
        {
            _questionrepository = Repository;
            _unitofwork = UnitOfWork;
        }

        public void ModifyQuestionRating(int questionId, int newRating)
        {
            _questionrepository.Query().Where(_ => _.QuestionId == questionId).SingleOrDefault().Rating = newRating ;   
        }

        public void ModifyQuestionDifficulty(int questionId, Difficulty newDifficulty)
        {
            _questionrepository.Query().Where(_ => _.QuestionId == questionId).SingleOrDefault().Difficulty = newDifficulty;
        }

        public IQueryable<Question> GetAllQuestionsByType (Type questionType)
        {
            if (questionType == typeof(Brief))
                return _questionrepository.Query().OfType<Brief>();
            if (questionType == typeof(Match))
                return _questionrepository.Query().OfType<Match>();
            if (questionType == typeof(Custom))
                return _questionrepository.Query().OfType<Custom>();
            if (questionType == typeof(Choice))
                return _questionrepository.Query().OfType<Choice>();
            return null;
            //Should throw a typed exception saying that the questionType is invalid
        }

        public Question AddQuestion(Question question)
        {
           return _questionrepository.Add(question);
        }

        public Question RemoveQuestion(Question question)
        {
           return _questionrepository.Remove(question);
        }
    }
}