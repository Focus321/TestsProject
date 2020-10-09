using System.Windows;
using System.Windows.Controls;
using Teacher_Program.Models;
using Teacher_Program.Service;
using Teacher_Program.TestWindow;
using Teacher_Program.ViewModels;

namespace Teacher_Program.LoginWindow
{
    public partial class SignIn : Page
    {
        private ConnectService _connectService;
        private TestServices _testServices;

        public SignIn()
        {
            InitializeComponent();
            _connectService = (Application.Current.MainWindow as MainWindow)._connectService;
            _testServices = (Application.Current.MainWindow as MainWindow)._testServices;
        }

        private void IsEnabledLoginButton(object sender, TextChangedEventArgs e)
        {
            if (loginTextBox.Text != "" && passwordTextBox.Password != "")
                loginButton.IsEnabled = true;
            else loginButton.IsEnabled = false;
        }
        private void passwordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text != "" && passwordTextBox.Password != "")
                loginButton.IsEnabled = true;
            else loginButton.IsEnabled = false;
        }

        private async void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            var command = new Command() { Teacher = new TeacherViewModel() { Login = loginTextBox.Text, Password = passwordTextBox.Password }, AdminCommand = AdminCommandServer.SignIn };
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
                else MessageBox.Show("Неверный логин или пароль");
            }
            else MessageBox.Show("Сервер не отвечает");
        }
    }
}