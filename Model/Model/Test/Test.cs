using System;
using System.Collections.Generic;
using ParikshaModel.Model.User;

namespace ParikshaModel.Model
{
    /// <summary>
    /// Test represents a collection of Questions for a Subject created by a User
    /// </summary>
    public class Test
    {   
        /// <summary>
        /// Gets or sets the Id for Test
        /// </summary>
        public int TestId { get; set; }

        /// <summary>
        /// Gets or sets the Date on which the Test was created
        /// </summary>
        public DateTime DateOfCreation { get; set; }
  
        /// <summary>
        /// Gets or sets the Subject for which the Test was created
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Gets or sets the User who created the test
        /// </summary>
        public virtual UserDetail Creator { get; set; }

        /// <summary>         
        /// Gets or sets the Questions
        /// </summary>
        public virtual ICollection<Question> Questions { get; set; }

    }
}