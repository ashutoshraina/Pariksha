using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    /// <summary>
    /// Standard is the entity which describes a grade e.g. kindergarten, first , second  
    /// </summary>
    public class Standard
    {
        /// <summary>
        /// Gets or sets the StandardId
        /// </summary>
        public int StandardId { get; set; }

        /// <summary>
        /// Gets or sets the StandardName
        /// </summary>
        public string StandardName { get; set; }        
        
        /// <summary>
        /// Gets or sets the Subjects that belong to a Standard
        /// </summary>
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}