using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Appraisal { get; set; }
        public string ImagePath { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public List<Answer> Answers { get; set; }       
        public Question()
        {
            Answers = new List<Answer>();
        }
    }
}