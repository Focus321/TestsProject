using Business_Layer.Service;
using Business_Layer.Models;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public class GetTestTeacherHandler : Handler
    {
        public GetTestTeacherHandler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService)
            : base(loginStudentService, loginTeacherService, testService, testTeacherService) { }
        public override async Task HandlerRequest(Command command, Client client)
        {
            if (command.UserCommand == UserCommandServer.NoCommand && command.AdminCommand == AdminCommandServer.GetTest)
            {
                Command sendCommand = new Command();
                sendCommand.Test = await TestTeacherService.GeTestAsync(command.Test.Id);
                client.SendCommand(sendCommand);
            }
            else if (Successor != null) await Successor.HandlerRequest(command, client);
        }
    }
}