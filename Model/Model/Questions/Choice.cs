using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    public class Choice : Question
    {
        public string QuestionText { get; set; }

        public List<string> Choices { get; set; }

        public List<string> Answers { get; set; }

        public bool IsMultiplechoice { get; set; }
    }
}