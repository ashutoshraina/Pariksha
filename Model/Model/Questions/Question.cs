using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int Rating { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual UserDetail Creator { get; set; }
        public virtual Subject Subject { get; set; }
    }
}