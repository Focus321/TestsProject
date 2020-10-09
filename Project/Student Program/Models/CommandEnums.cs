using System;
using System.Collections.Generic;
using System.Text;

namespace Student_Program.Models
{
    public enum UserCommandServer
    {
        NoCommand,
        SignIn,
        SignUp,
        GetListTests,
        GetTest
    }
    public enum AdminCommandServer
    {
        NoCommand,
        SignIn,
        SignUp,
        GetListTests,
        GetTest
        //AddTest
    }
}