using System;

namespace ParikshaModel.Model
{
    public class Brief : Question
    {
        public string QuestionText { get; set; }

        public string Answer { get; set; }

        // true for fill in the blanks and false for a loing answers
        public bool Short { get; set; }
    }
}