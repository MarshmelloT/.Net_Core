using common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //initDB();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void initDB()
        {
            var dbOptions = new DbContextOptionsBuilder<PastryMSDB>()
                            .UseSqlServer(@"data source=.;Initial catalog=PastryMSDB;integrated security=True")
                            .Options;

            PastryMSDB db = new PastryMSDB(dbOptions);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            CustomerInfo userInfo = new CustomerInfo();
            userInfo.Id = Guid.NewGuid().ToString();
            userInfo.Account = "admin";
            userInfo.Pwd = MD5Help.GenerateMD5("123456");
            userInfo.CreateTime = DateTime.Now;
            userInfo.CustomerName = "��ʼ���������û�";


            db.CustomerInfo.Add(userInfo);//������ݿ�
            db.SaveChanges();//�ύ���ݿ�


        }
    }
}
