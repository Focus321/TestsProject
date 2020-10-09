using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
   public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Test> Tests { get; set; }
        public Teacher()
        {
            Tests = new List<Test>();
        }
    }
}