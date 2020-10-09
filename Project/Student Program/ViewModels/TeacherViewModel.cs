using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Program.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<TestViewModel> Tests { get; set; }
    }
}