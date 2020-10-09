using Business_Layer.Service;
using Business_Layer.Models;
using Business_Layer.ViewModels;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public class SignUpTeacherHandler : Handler
    {
        public SignUpTeacherHandler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService) 
            : base(loginStudentService, loginTeacherService, testService, testTeacherService) { }
        public override async Task HandlerRequest(Command command, Client client)
        {
            if (command.UserCommand == UserCommandServer.NoCommand && command.AdminCommand == AdminCommandServer.SignUp)
            {
                Command sendCommand = new Command();
                if (await LoginTeacherService.AddNewUserAsync(new RegistrationViewModel() { FullName = command.Teacher.FullName, Login = command.Teacher.Login, Password = command.Teacher.Password, Subject= command.Teacher.Subject }))
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