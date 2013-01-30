using System;
using System.Collections.Generic;
using System.Linq;

namespace ParikshaModel.Model
{
    public class Match : Question
    {
        private IEnumerable<string> _leftChoices;

        private IEnumerable<string> _rightChoices;

        public string QuestionText { get; set; }

        public string LeftChoices 
        {
            get
            {
                return string.Join(";", _leftChoices);
            }
            set
            {
                _leftChoices = value != null ? value.Split(';').AsEnumerable() : null;
            }            
        }

        public string RightChoices 
        {
            get
            {
                return string.Join(";", _rightChoices);
            }
            set
            {
                _rightChoices = value != null ? value.Split(';').AsEnumerable() : null;
            }            
        }
    }
}