using Business_Layer.Models;
using Business_Layer.Service;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public abstract class Handler
    {
        protected LoginStudentService LoginStudentService { get; }
        protected LoginTeacherService LoginTeacherService { get; }
        protected TestStudentService TestStudentService { get; }
        protected TestTeacherService TestTeacherService { get; }
        public Handler Successor { get; set; }
        public Handler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService)
        {
            LoginStudentService = loginStudentService;
            LoginTeacherService = loginTeacherService;
            TestStudentService = testService;
            TestTeacherService = testTeacherService;
        }
        public abstract Task HandlerRequest(Command command, Client client);
    }
}