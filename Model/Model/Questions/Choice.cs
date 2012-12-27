using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    public class Choice : Question
    {
        public String QuestionText { get; set; }
        public List<String> Choices { get; set; }
        public List<String> Answers { get; set; }
        public bool Multiplechoice { get; set; }
    }
}