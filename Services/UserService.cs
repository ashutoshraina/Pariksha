using EFRepository.Infrastructure;
using ParikshaModel.Model;
using System.Linq;
namespace ParikshaServices
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService
    {
        private IRepository<UserDetail> _userrepository;
        private IUnitOfWork _unitofwork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="unitOfWork"></param>
        public UserService(IRepository<UserDetail> userRepository, IUnitOfWork unitOfWork)
        {
            _userrepository = userRepository;
            _unitofwork = unitOfWork;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDetail CreateNewUser(UserDetail user)
        {
            return _userrepository.Add(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDetail RemoveUser(UserDetail user)
        {
            return _userrepository.Remove(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        public IQueryable<UserDetail> GetAllUsersByRole(UserRole userRole)
        {
           return _userrepository.Query().Where(_ => _.UserRole == userRole);
        }
    }
}