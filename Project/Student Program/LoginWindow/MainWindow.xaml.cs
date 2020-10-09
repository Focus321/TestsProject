using MahApps.Metro.Controls;
using Student_Program.Service;
using System;
using System.Windows;

namespace Student_Program.LoginWindow
{
    public partial class MainWindow : MetroWindow
    {
        public ConnectService _connectService;
        public TestServices _testServices;
        public MainWindow() { InitializeComponent(); }
        public MainWindow(ConnectService connectService, TestServices testServices)
        {
            InitializeComponent();
            _connectService = connectService;
            _testServices = testServices;
        }

        private void SignInButtonClick(object sender, RoutedEventArgs e) { frame.Navigate(new Uri("pack://application:,,,/LoginWindow/SignIn.xaml")); }
        private void SignUpButtonClick(object sender, RoutedEventArgs e) { frame.Navigate(new Uri("pack://application:,,,/LoginWindow/SignUp.xaml")); }
        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e) 
        {
            await _connectService.Start();
        }
    }
}