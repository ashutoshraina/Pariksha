using System;

namespace ParikshaModel.Model
{
    /// <summary>
    /// Represents a Question which has an Image associated with it
    /// </summary>
    public class Custom : Question
    {
        /// <summary>
        /// Gets or sets QuestionText
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets Answer
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets ImagePath
        /// </summary>
        /// <remarks>ImagePath is the path on the server</remarks>
        public string ImagePath { get; set; }
    }
}