using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Test
    {   
        /// <summary>
        /// 
        /// </summary>
        public int TestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOfCreation { get; set; }
  
        /// <summary>
        /// 
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserDetail Creator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Question> Questions { get; set; }
    }
}