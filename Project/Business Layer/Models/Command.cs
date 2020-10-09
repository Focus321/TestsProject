using Business_Layer.ViewModels;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Models
{
    public class Command
    {
        public int Id { get; set; }
        public StudentViewModel Student { get; set; }
        public TeacherViewModel Teacher { get; set; }
        public List<TestViewModel> Tests { get; set; }
        public TestViewModel Test { get; set; }
        public bool IsSignIn { get; set; }

        public UserCommandServer UserCommand { get; set; }
        public AdminCommandServer AdminCommand { get; set; }
    }
}