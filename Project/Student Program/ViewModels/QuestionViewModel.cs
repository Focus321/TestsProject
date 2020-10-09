using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Program.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int Appraisal { get; set; }
        public string ImagePath { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}