using System;
using System.Collections.Generic;
using ParikshaModel.Model.User;

namespace ParikshaModel.Model
{
    /// <summary>
    /// Question is the base type which describes a Question. Other types derive from Question.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Gets or sets the QuestionId
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the Rating
        /// </summary>
        public int Rating { get; set; }
        
        /// <summary>
        /// Gets or sets the Difficulty
        /// </summary>
        public Difficulty Difficulty { get; set; }
        
        /// <summary>
        /// Gets or sets the DateTime on which the question is created
        /// </summary>
        public DateTime DateOfCreation { get; set; }
        
        /// <summary>
        /// Gets or sets the User who created the Question
        /// </summary>
        public virtual UserDetail Creator { get; set; }
        
        /// <summary>
        /// Gets or sets the Subject to which the Question belongs
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the Tests
        /// </summary>
        public virtual ICollection<Test> Tests { get; set; }

    }
}