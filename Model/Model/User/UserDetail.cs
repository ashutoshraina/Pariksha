using System;
using System.Collections.Generic;
namespace ParikshaModel.Model
{
    public class UserDetail
    {
        public int UserDetailId { get; set; }
        public String Name { get; set; }     
        public String Password { get; set; }
        public String UserRole { get; set; }
        public DateTime DateOfCreation{  get; set;}
        public ICollection<Question> Questions { get; set; }
    }
}