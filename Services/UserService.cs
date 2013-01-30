using EFRepository.Infrastructure;
using ParikshaModel.Model;
using System.Linq;
using System;
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
        /// <param name="password"></param>
        /// <returns>True if the Password is strong.</returns>
        public bool IsStrongPassword(string password)
        {
            // Minimum and Maximum Length of field - 6 to 12 Characters
            if (password.Length < 6 || password.Length > 12)
                return false;

            // Numeric Character - At least one character
            if (!password.Any(c => char.IsDigit(c)))
                return false;

            // At least one Capital Letter
            if (!password.Any(c => char.IsUpper(c)))
                return false;

            // Repetitive Characters - Allowed only two repetitive characters
            var repeatCount = 0;
            var lastChar = '\0';
            foreach (var c in password)
            {
                if (c == lastChar)
                    repeatCount++;
                else
                    repeatCount = 0;
                if (repeatCount == 2)
                    return false;
                lastChar = c;
            }

            return true;
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