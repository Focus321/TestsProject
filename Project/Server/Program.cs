using Business_Layer.Config;
using Business_Layer.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.ChainOfResponsibility;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static TCPServer server; // сервер
        public static IServiceProvider ServiceProvider;
        public static IConfiguration Configuration;
        static void Main(string[] args)
        {
            OnStartup();
            try
            {
                Task.Factory.StartNew(() => { server.Listen(); });
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static protected void OnStartup()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, false);
            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigurationService(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            server = ServiceProvider.GetRequiredService<TCPServer>();
        }
        static private void ConfigurationService(IServiceCollection service)
        {
            ConfigurationManagerBLL.Configuration(service, Configuration);

            service.AddTransient(typeof(TCPServer));

            service.AddTransient(typeof(SignInHandler));
            service.AddTransient(typeof(SignUpHandler));

            service.AddTransient(typeof(SignInTeacherHandler));
            service.AddTransient(typeof(SignUpTeacherHandler));

            service.AddTransient(typeof(GetListTestsHandler));
            service.AddTransient(typeof(GetTestHandler));

            service.AddTransient(typeof(GetListTestsTeacherHandler));
            service.AddTransient(typeof(GetTestTeacherHandler));


            service.AddTransient(typeof(LoginStudentService));
            service.AddTransient(typeof(LoginTeacherService));
            service.AddTransient(typeof(TestStudentService));
            service.AddTransient(typeof(TestTeacherService));
            service.AddSingleton(typeof(ConnectService));
        }
    }
}