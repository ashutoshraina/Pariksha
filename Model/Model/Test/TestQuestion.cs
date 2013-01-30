namespace ParikshaModel.Model
{
    /// <summary>
    /// Represents the M..M association between Test and Question
    /// </summary>
    public class TestQuestion
    {   
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int TestQuestionId { get; set; }     
        
        /// <summary>
        /// Gets or sets the Test
        /// </summary>
        public virtual Test Test { get; set; }      
        
        /// <summary>
        /// Gets or sets the Question
        /// </summary>
        public virtual Question Question { get; set; }
    }
}