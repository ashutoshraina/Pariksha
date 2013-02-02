using EFRepository.Infrastructure;
using EFRepository.Context;
using ParikshaModel.Model;
using System;
using System.Linq;

namespace ParikshaServices
{
    /// <summary>
    /// Provides methods which allow operations on Questions
    /// </summary>
    public class QuestionService
    {
        private IRepository<Question> _questionRepository;

        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initialises a new instance of QuestionService <see cref="QuestionService"/>
        /// </summary>
        /// <param name="Repository">Repository</param>
        /// <param name="UnitOfWork">UnitOfWork</param>                 
        public QuestionService(IRepository<Question> Repository, IUnitOfWork UnitOfWork)
        {
            _questionRepository = Repository;
            _unitOfWork = UnitOfWork;
        }

        /// <summary>
        /// Changes the Rating of the Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <param name="newRating">The New Rating</param>
        public void ModifyQuestionRating(int questionId, int newRating)
        {
            _questionRepository.Query().Where(_ => _.QuestionId == questionId).SingleOrDefault().Rating = newRating; 
        }

        /// <summary>
        /// Changes the Difficulty of the Question
        /// </summary>
        /// <param name="questionId">The Id of the Question</param>
        /// <param name="newDifficulty">The new Difficulty</param>
        public void ModifyQuestionDifficulty(int questionId, Difficulty newDifficulty)
        {
            _questionRepository.Query().Where(_ => _.QuestionId == questionId).SingleOrDefault().Difficulty = newDifficulty;
        }

        /// <summary>
        /// Returns All questions belonging to the Type specified
        /// </summary>
        /// <param name="questionType">The Sub Type of the question to return</param>
        /// <returns>An IQueryable of <see cref="Question"/> which includes the questions that belong to the Type specified </returns>
        /// <remarks>questionType must derive from Question</remarks>
        public IQueryable<Question> GetAllQuestionsByType(Type questionType)
        {
            if (questionType == typeof(Brief))
            {
                return _questionRepository.Query().OfType<Brief>();
            }
            
            if (questionType == typeof(Match))
            {
                return _questionRepository.Query().OfType<Match>();
            }
            
            if (questionType == typeof(Custom))
            {
                return _questionRepository.Query().OfType<Custom>();
            }

            if (questionType == typeof(Choice))
            {
                return _questionRepository.Query().OfType<Choice>(); 
            }

            return null;            
        }

        /// <summary>
        /// Adds a Question
        /// </summary>
        /// <param name="question">Question to be Added</param>
        /// <returns>The Added question</returns>
        public Question AddQuestion(Question question)
        {
           return _questionRepository.Add(question);
        }

        /// <summary>
        /// Removes a Question
        /// </summary>
        /// <param name="question">Question to Remove</param>
        /// <returns>The question removed</returns>
        public Question RemoveQuestion(Question question)
        {
           return _questionRepository.Remove(question);
        }
    }
}