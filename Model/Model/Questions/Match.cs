using System;
using System.Collections.Generic;
using System.Linq;

namespace ParikshaModel.Model
{
    public class Match : Question
    {
        private String leftchoices;
        private String rightchoices;

        public String QuestionText { get; set; }
        public IEnumerable<String> LeftChoices 
        {
            get 
            { 
                return leftchoices.Split(',').ToList();
            } 
            set 
            { 
                leftchoices = String.Join(",",LeftChoices);
            } 
        }
        public IEnumerable<String> RightChoices 
        { 
            get
            {
                return rightchoices.Split(',').ToList();
            }
            set 
            {
                rightchoices = String.Join(",", LeftChoices);
            } 
        }
    }
}