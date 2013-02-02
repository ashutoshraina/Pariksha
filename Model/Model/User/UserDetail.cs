using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    /// <summary>
    /// UserDetail represents the details of a User
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        /// Gets or sets the UserDetailId
        /// </summary>
        public int UserDetailId { get; set; }
        
        /// <summary>
        /// Gets or sets the Name of the User
        /// </summary>
        public string Name { get; set; }     
        
        /// <summary>
        /// Gets or sets the Password of the User
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Gets or sets the Role for the User
        /// </summary>
        public UserRole UserRole { get; set; }
        
        /// <summary>
        /// Gets or sets the Date of Creation for the User
        /// </summary>
        public DateTime DateOfCreation { get; set; }

        /// <summary>
        /// Gets or sets the Questions created by the User
        /// </summary>
        public virtual ICollection<Question> Questions { get; set; }
    }
}