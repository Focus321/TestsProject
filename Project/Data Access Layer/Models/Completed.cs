using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class Completed
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public List<Result> Results { get; set; }
        public Completed()
        {
            Results = new List<Result>();
        }
    }
}