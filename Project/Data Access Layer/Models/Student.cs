using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Completed> Completeds { get; set; }
        public Student()
        {
            Completeds = new List<Completed>();
        }
    }
}