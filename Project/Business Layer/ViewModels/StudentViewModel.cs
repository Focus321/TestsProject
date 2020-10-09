using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}