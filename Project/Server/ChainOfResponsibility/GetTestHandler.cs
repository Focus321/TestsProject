using Business_Layer.Service;
using Business_Layer.Models;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public class GetTestHandler : Handler
    {
        public GetTestHandler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService)
            : base(loginStudentService, loginTeacherService, testService, testTeacherService) { }
        public override async Task HandlerRequest(Command command, Client client)
        {
            if (command.UserCommand == UserCommandServer.GetTest && command.AdminCommand == AdminCommandServer.NoCommand)
            {
                Command sendCommand = new Command();
                sendCommand.Test = await TestStudentService.GeTestAsync(command.Test.Id);
                client.SendCommand(sendCommand);
            }
            else if (Successor != null) await Successor.HandlerRequest(command, client);
        }
    }
}