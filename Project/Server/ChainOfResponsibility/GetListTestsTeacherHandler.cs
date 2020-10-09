using Business_Layer.Service;
using Business_Layer.Models;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public class GetListTestsTeacherHandler : Handler
    {
        public GetListTestsTeacherHandler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService)
            : base(loginStudentService, loginTeacherService, testService, testTeacherService) { }
        public override async Task HandlerRequest(Command command, Client client)
        {
            if (command.UserCommand == UserCommandServer.NoCommand && command.AdminCommand == AdminCommandServer.GetListTests)
            {
                Command sendCommand = new Command();
                sendCommand.Tests = await TestTeacherService.GetListTests(command.Id);
                client.SendCommand(sendCommand);
            }
            else if (Successor != null) await Successor.HandlerRequest(command, client);
        }
    }
}