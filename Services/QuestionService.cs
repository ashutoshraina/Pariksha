using EFRepository.Infrastructure;
using EFRepository.Context;
using ParikshaModel.Model;
using System;
using System.Linq;
namespace ParikshaServices
{
    /// <summary>
    /// 
    /// </summary>
    public class QuestionService
    {

        private IRepository<Question> _questionrepository;

        private IUnitOfWork _unitofwork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Repository"></param>
        /// <param name="UnitOfWork"></param>
        public QuestionService(IRepository<Question> Repository, IUnitOfWork UnitOfWork)
        {
            _questionrepository = Repository;
            _unitofwork = UnitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="newRating"></param>
        public void ModifyQuestionRating(int questionId, int newRating)
        {
            _questionrepository.Query().Where(_ => _.QuestionId == questionId).SingleOrDefault().Rating = newRating; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="newDifficulty"></param>
        public void ModifyQuestionDifficulty(int questionId, Difficulty newDifficulty)
        {
            _questionrepository.Query().Where(_ => _.QuestionId == questionId).SingleOrDefault().Difficulty = newDifficulty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionType"></param>
        /// <returns></returns>
        public IQueryable<Question> GetAllQuestionsByType( Type questionType)
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public Question AddQuestion(Question question)
        {
           return _questionrepository.Add(question);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public Question RemoveQuestion(Question question)
        {
           return _questionrepository.Remove(question);
        }
    }
}