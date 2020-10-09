using Student_Program.Models;
using Student_Program.Service;
using Student_Program.TestWindow;
using Student_Program.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Student_Program.LoginWindow
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
           var command = new Command() {Student= new StudentViewModel() { Login = loginTextBox.Text, Password = passwordTextBox.Password },  UserCommand = UserCommandServer.SignIn  };
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