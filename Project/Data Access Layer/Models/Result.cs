using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int FinalResult { get; set; }

        public int CompletedId { get; set; }
        public Completed Completed { get; set; }
    }
}