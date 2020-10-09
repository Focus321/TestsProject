using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string TestName { get; set; }
        public int NumberOfAttempts { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Question> Questions { get; set; }
        public List<Completed> Completeds { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            Completeds = new List<Completed>();
        }
    }
}