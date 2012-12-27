using System;

namespace ParikshaModel.Model
{
    public class Brief : Question
    {
        public String QuestionText { get; set; }
        public String Answer { get; set; }
        //true for fill in the blanks and false for a loing answers
        public bool Short { get; set; }
    }
}