
namespace ParikshaModel.Model
{
    /// <summary>
    /// Represents a Question with only a textual answer
    /// </summary>
    public class Brief : Question
    {
        /// <summary>
        /// Gets or sets the QuestionText
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets the Answer
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Question is Short Answer
        /// </summary> 
        /// <remarks>True for fill in the blanks and false for a long answers</remarks>
        public bool Short { get; set; }
    }
}