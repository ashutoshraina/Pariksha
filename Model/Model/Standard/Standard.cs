using System;
using System.Collections.Generic;
namespace ParikshaModel.Model
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }        
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}