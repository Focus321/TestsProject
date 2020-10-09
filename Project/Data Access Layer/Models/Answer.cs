using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Data_Access_Layer.Models
{
   public class Answer
    {
        public int Id { get; set; }
        public string ResponseText { get; set; }
        public bool Right { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}