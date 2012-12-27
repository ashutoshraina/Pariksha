using System;
using System.Collections.Generic;
namespace ParikshaModel.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public String SubjectName { get; set; }
        public String SubjectCategory { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}