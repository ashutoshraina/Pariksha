using System;
using System.Collections.Generic;
namespace ParikshaModel.Model
{
    public class UserDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserDetailId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }     
        
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserRole UserRole { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOfCreation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Question> Questions { get; set; }
    }
}