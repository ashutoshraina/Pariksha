
namespace ParikshaModel.Model
{
    public class TestQuestion
    {        
        public int TestQuestionId { get; set; }
     
        public virtual Test Test { get; set; }
      
        public virtual Question Question { get; set; }
    }
}