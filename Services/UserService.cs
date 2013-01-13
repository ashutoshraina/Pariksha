using EFRepository.Infrastructure;
using ParikshaModel.Model;
using System.Linq;
namespace ParikshaServices
{
    public class UserService
    {
        private IRepository<UserDetail> _userrepository;
        private IUnitOfWork _unitofwork;

        public UserService(IRepository<UserDetail> userRepository,IUnitOfWork unitOfWork)
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

        public IQueryable<UserDetail> GetAllUsersByRole(UserRole userRole)
        {
           return  _userrepository.Query().Where(_ => _.UserRole == userRole);
        }
    }
}