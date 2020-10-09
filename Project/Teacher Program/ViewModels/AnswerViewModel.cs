using System;
using System.Collections.Generic;
using System.Text;

namespace Teacher_Program.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string ResponseText { get; set; }
        public bool Right { get; set; }
    }
}