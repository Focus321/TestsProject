﻿using Business_Layer.Service;
using Business_Layer.Models;
using Business_Layer.ViewModels;
using System.Threading.Tasks;

namespace Server.ChainOfResponsibility
{
    public class SignInHandler : Handler
    {
        public SignInHandler(LoginStudentService loginStudentService, LoginTeacherService loginTeacherService, TestStudentService testService, TestTeacherService testTeacherService)
            : base(loginStudentService, loginTeacherService, testService, testTeacherService) { }
        public override async Task HandlerRequest(Command command, Client client)
        {
            if (command.UserCommand == UserCommandServer.SignIn && command.AdminCommand == AdminCommandServer.NoCommand)
            {
                Command sendCommand = new Command();
                if (await LoginStudentService.AuthorizationAsync(new AuthorizationViewModel() { Login = command.Student.Login, Password = command.Student.Password }))
                {
                    sendCommand.IsSignIn = true;
                    sendCommand.Id = LoginStudentService.CurrentUser.Id;
                }
                else sendCommand.IsSignIn = false;
                client.SendCommand(sendCommand);
            }
            else if (Successor != null) await Successor.HandlerRequest(command, client);
        }
    }
}