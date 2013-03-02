
namespace ParikshaModel.Model
{
    /// <summary>
    /// Represents a Question with multiple choice format
    /// </summary>
    public class Choice : Question
    {
        /// <summary>
        /// Gets or sets QuestionText
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets Choices
        /// </summary>
        /// <remarks> Choices is a comma separated list of strings</remarks>
        public string Choices { get; set; }

        /// <summary>
        /// Gets or sets Answers
        /// </summary>
        /// <remarks> Answers is a comma separated list of strings</remarks>
        public string Answers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Answer is Multple Choice
        /// </summary>
        public bool IsMultiplechoice { get; set; }
    }
}