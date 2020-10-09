using MahApps.Metro.Controls;
using System.Windows;
using Student_Program.Service;

namespace Student_Program.TestWindow
{
    public partial class TestMainWindow : MetroWindow
    {
        private ConnectService _connectService;
        private TestServices _testServices;

        public TestMainWindow() { InitializeComponent(); }
        public TestMainWindow(ConnectService connectService, TestServices testServices)
        {
            InitializeComponent();
            _connectService = connectService;
            _testServices = testServices;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _testServices.GetPage(mainWrapPanel, 0);
        }           

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_testServices.PageNumber == 1) return;
            else if (_testServices.PageNumber == 4) _testServices.PageNumber = 2;
            else _testServices.PageNumber--;
            await _testServices.GetPage(mainWrapPanel, 0);
        }            
    }
}