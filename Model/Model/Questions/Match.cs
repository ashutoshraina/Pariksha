using System;
using System.Collections.Generic;
using System.Linq;

namespace ParikshaModel.Model
{
    /// <summary>
    /// Represents a Question with Match types. Values in Left Column are to be matched with Values in right column
    /// </summary>
    public class Match : Question
    {
        private IEnumerable<string> _leftChoices;

        private IEnumerable<string> _rightChoices;

        /// <summary>
        /// Gets or sets QuestionText
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets LeftChoices
        /// </summary>
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

        /// <summary>
        /// Gets or sets RightChoices
        /// </summary>
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