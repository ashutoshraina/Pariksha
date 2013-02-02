using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    /// <summary>
    /// Subject is a particular course that belongs to a Standard
    /// Each subject must belong to a Standard
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Gets or sets the SubjectId
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the SubjectName
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Gets or sets the SubjectCategory
        /// </summary>
        public string SubjectCategory { get; set; }
  
        /// <summary>
        /// Gets a Collecttion of questions that belong to the Subject
        /// </summary>
        public virtual ICollection<Question> Questions { get; private set; }

        /// <summary>
        /// Gets or sets the Standard to which the Subject belongs
        /// </summary>
        public virtual Standard Standard { get; set; }
    }
}