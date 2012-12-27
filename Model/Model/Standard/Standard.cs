using System;
using System.Collections.Generic;
namespace ParikshaModel.Model
{
    public class Standard
    {
        public int StandardId { get; set; }
        public String StandardName { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}