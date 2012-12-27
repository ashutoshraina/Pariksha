using EFRepository.Infrastructure;
using ParikshaModel.Model;
using System.Linq;
namespace ParikshaServices
{
    public class UserService
    {
        private IRepository<UserDetail> _userrepository;
        private IUnitOfWork _unitofwork;

        public UserService(IUnitOfWork unitOfWork, IRepository<UserDetail> userRepository)
        {
            _userrepository = userRepository;
            _unitofwork = unitOfWork;
        }
                
        public UserDetail CreateNewUser(UserDetail user)
        {
            return _userrepository.Add(user);
        }

        public UserDetail RemoveUser(UserDetail user)
        {
            return _userrepository.Remove(user);
        }

        public IQueryable<UserDetail> GetAllUsersByRole(string userRole)
        {
           return  _userrepository.Query().Where(_ => _.UserRole == userRole);
        }
    }
}