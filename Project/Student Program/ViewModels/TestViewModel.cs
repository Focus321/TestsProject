using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Program.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string TestName { get; set; }
        public int NumberOfAttempts { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}