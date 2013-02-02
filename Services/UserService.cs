using EFRepository.Infrastructure;
using ParikshaModel.Model;
using System.Linq;
using System;

namespace ParikshaServices
{
    /// <summary>
    /// Represents the Service class which the Layers sitting above it can call to perform operations on a UserDetail
    /// </summary>
    public class UserService
    {
        private IRepository<UserDetail> _userRepository;

        private IUnitOfWork _unitofwork;

        /// <summary>
        /// Constructor which injects the Repository and the UnitOfWork into the Service 
        /// </summary>
        /// <param name="userRepository">An implementation of IRepository <see cref="UserDetail"/></param>
        /// <param name="unitOfWork">An implementation of IUnitOfWork <see cref="IUnitOfWork"/></param>
        public UserService(IRepository<UserDetail> userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitofwork = unitOfWork;
        }

        /// <summary>
        /// Checks if the Password is Strong
        /// </summary>
        /// <param name="password">Password of the User</param>
        /// <returns>True if the Password is strong.</returns>
        public bool IsStrongPassword(string password)
        {
            // Minimum and Maximum Length of field - 6 to 12 Characters
            if (password.Length < 6 || password.Length > 12)
            {
                return false;
            }

            // Numeric Character - At least one character
            if (!password.Any(c => char.IsDigit(c)))
            {
                return false;
            }

            // At least one Capital Letter
            if (!password.Any(c => char.IsUpper(c)))
            {
                return false;
            }

            // Repetitive Characters - Allowed only two repetitive characters
            var repeatCount = 0;
            var lastChar = '\0';
            foreach (var c in password)
            {
                if (c == lastChar)
                {
                    repeatCount++;
                }
                else
                {
                    repeatCount = 0;
                }

                if (repeatCount == 2)
                {
                    return false;
                }

                lastChar = c;
            }

            return true;
        }

        /// <summary>
        /// Creates a new User
        /// </summary>
        /// <param name="user">New User to be Created</param>
        /// <returns>The created User</returns>
        public UserDetail CreateNewUser(UserDetail user)
        {
            return _userRepository.Add(user);
        }

        /// <summary>
        /// Removes the User
        /// </summary>
        /// <param name="user">User to be Removed</param>
        /// <returns>The removed User</returns>
        public UserDetail RemoveUser(UserDetail user)
        {
            return _userRepository.Remove(user);
        }

        /// <summary>
        /// Gets the Users in the particular Role
        /// </summary>
        /// <param name="userRole">UserRole to filter the Users on</param>
        /// <returns>An IQueryable of UserDetil</returns>
        public IQueryable<UserDetail> GetAllUsersByRole(UserRole userRole)
        {
           return _userRepository.Query().Where(_ => _.UserRole == userRole);
        }
    }
}