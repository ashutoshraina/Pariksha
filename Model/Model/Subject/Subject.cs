using System;
using System.Collections.Generic;
namespace ParikshaModel.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Gets or sets the SubjectId
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubjectCategory { get; set; }
  
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Question> Questions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Standard Standard { get; set; }
    }
}