using Business_Layer.Service;
using Business_Layer.Models;
using Business_Layer.ViewModels;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public class SignInTeacherHandler : Handler
    {
        public SignInTeacherHandler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService)
            : base(loginStudentService, loginTeacherService, testService, testTeacherService) { }
        public override async Task HandlerRequest(Command command, Client client)
        {
            if (command.UserCommand == UserCommandServer.NoCommand && command.AdminCommand == AdminCommandServer.SignIn)
            {
                Command sendCommand = new Command();
                if (await LoginTeacherService.AuthorizationAsync(new AuthorizationViewModel() { Login = command.Teacher.Login, Password = command.Teacher.Password }))
                {
                    sendCommand.IsSignIn = true;
                    sendCommand.Id = LoginTeacherService.CurrentUser.Id;
                }
                else sendCommand.IsSignIn = false;
                client.SendCommand(sendCommand);
            }
            else if (Successor != null) await Successor.HandlerRequest(command, client);
        }
    }
}