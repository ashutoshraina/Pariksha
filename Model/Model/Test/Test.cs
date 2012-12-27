using System;
using System.Collections.Generic;

namespace ParikshaModel.Model
{
    public class Test
    {        
        public int TestId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int UserDetailId { get; set; }
        public virtual UserDetail Creator { get; set; }
    }
}