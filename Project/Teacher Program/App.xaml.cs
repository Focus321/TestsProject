using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teacher_Program.LoginWindow;
using Teacher_Program.Service;
using Teacher_Program.TestWindow;
using System;
using System.Windows;

namespace Teacher_Program
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