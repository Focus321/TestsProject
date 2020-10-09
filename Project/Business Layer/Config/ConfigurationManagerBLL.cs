using Business_Layer.Service;
using Data_Access_Layer.Context;
using Data_Access_Layer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Config
{
    public class ConfigurationManagerBLL
    {
        public static void Configuration(IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<TestingDB>(option => option.UseSqlServer(config.GetConnectionString("SqlConnection")));
            service.AddTransient(typeof(UnitOfWork));
        }
    }
}