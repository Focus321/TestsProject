using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student_Program.LoginWindow;
using Student_Program.Service;
using Student_Program.TestWindow;
using System;
using System.Windows;

namespace Student_Program
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            Configrationservice(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            ServiceProvider.GetRequiredService<MainWindow>().Show();
        }

        private void Configrationservice(IServiceCollection service)
        {
            service.AddTransient(typeof(MainWindow));
            service.AddTransient(typeof(TestMainWindow));
            service.AddSingleton(typeof(TestServices));
            service.AddSingleton(typeof(ConnectService));
        }
    }
}