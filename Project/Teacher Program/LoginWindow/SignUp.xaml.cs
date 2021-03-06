﻿using System.Windows;
using System.Windows.Controls;
using Teacher_Program.Models;
using Teacher_Program.Service;
using Teacher_Program.TestWindow;
using Teacher_Program.ViewModels;

namespace Teacher_Program.LoginWindow
{
    public partial class SignUp : Page
    {
        private ConnectService _connectService;
        private TestServices _testServices;
        public SignUp()
        {
            InitializeComponent();
            _connectService = (Application.Current.MainWindow as MainWindow)._connectService;
            _testServices = (Application.Current.MainWindow as MainWindow)._testServices;
        }

        private void IsEnabledLoginButton(object sender, TextChangedEventArgs e)
        {
            if (nicknameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Password != "" && subjectTextBox.Text != "")
                loginButton.IsEnabled = true;
            else loginButton.IsEnabled = false;
        }
        private void passwordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (nicknameTextBox.Text != "" && emailTextBox.Text != "" && passwordTextBox.Password != "" && subjectTextBox.Text != "")
                loginButton.IsEnabled = true;
            else loginButton.IsEnabled = false;
        }

        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            var command = new Command() { Teacher = new TeacherViewModel() { FullName = nicknameTextBox.Text, Login = emailTextBox.Text, Password = passwordTextBox.Password, Subject = subjectTextBox.Text}, AdminCommand = AdminCommandServer.SignUp };
            _connectService.SendCommand(command);
            var inBoxCommand = (await _connectService.ReadCommand());
            if (inBoxCommand != null)
            {
                _connectService.Id = inBoxCommand.Id;
                if (inBoxCommand.IsSignIn)
                {
                    TestMainWindow testMainWindow = new TestMainWindow(_connectService, _testServices);
                    testMainWindow.Show();
                    Application.Current.MainWindow.Close();
                }
                else MessageBox.Show("Это логин busy");
            }
            else MessageBox.Show("Сервер не отвечает");
        }
    }
}