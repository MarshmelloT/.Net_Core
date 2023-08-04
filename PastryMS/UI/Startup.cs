using BLL;
using DAL;
using IBLL;
using IDAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //注册session
            services.AddSession();

            services.AddDbContext<PastryMSDB>(options => options.UseSqlServer("name=ConnectionStrings:SqlStr"));

            //跨域
            services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });
            });

            //角色
            services.AddScoped<IRoleInfoDAL, RoleInfoDAL>();
            services.AddScoped<IRoleInfoBLL, RoleInfoBLL>();

            //绑定角色
            services.AddScoped<IR_UserInfo_RoleInfoDAL, R_UserInfo_RoleInfoDAL>();
            //services.AddScoped<IR_UserInfo_RoleInfoBLL, R_UserInfo_RoleInfoBLL>();

            //菜单
            services.AddScoped<IMenuInfoDAL, MenuInfoDAL>();
            services.AddScoped<IMenuInfoBLL, MenuInfoBLL>();

            //绑定菜单
            //services.AddScoped<IR_RoleInfo_MenuInfoBLL, R_RoleInfo_MenuInfoBLL>();
            services.AddScoped<IR_RoleInfo_MenuInfoDAL, R_RoleInfo_MenuInfosDAL>();

            services.AddScoped<IConsumableInfoDAL, ConsumableInfoDAL>();
            services.AddScoped<IConsumableInfoBLL, ConsumableInfoBLL>();

            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ICategoryBLL, CategoryBLL>();

            services.AddScoped<IWorkFlow_ModelBLL, WorkFlow_ModelBLL>();
            services.AddScoped<IWorkFlow_ModelDAL, WorkFlow_ModelDAL>();

            services.AddScoped<IWorkFlow_InstanceBLL, WorkFlow_InstanceBLL>();
            services.AddScoped<IWorkFlow_InstanceDAL, WorkFlow_InstanceDAL>();

            services.AddScoped<IWorkFlow_InstanceStepBLL, WorkFlow_InstanceStepBLL>();
            services.AddScoped<IWorkFlow_InstanceStepDAL, WorkFlow_InstanceStepDAL>();

            services.AddScoped<ICustomer_Refund_InstanceStepDAL, Customer_Refund_InstanceStepDAL>();
            services.AddScoped<ICustomer_Refund_InstanceStepBLL, Customer_Refund_InstanceStepBLL>();

            //客户信息表注册DAL和BLL
            services.AddScoped<ICustomerInfoDAL, CustomerInfoDAL>();
            services.AddScoped<ICustomerInfoBLL, CustomerInfoBLL>();

            services.AddScoped<IDessertInfoBLL, DessertInfoBLL>();
            services.AddScoped<IDessertInfoDAL, DessertInfoDAL>();

            services.AddScoped<IStaffInfoBLL, StaffInfoBLL>();
            services.AddScoped<IStaffInfoDAL, StaffInfoDAL>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            //启用跨域
            app.UseCors("MyCorsPolicy");
            app.UseAuthorization();
            //启用Session
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                     name: "Admin",
                     areaName: "Admin",
                   pattern: "{area:exists}/{controller=Account}/{action=LoginView}/{id?}");


                endpoints.MapAreaControllerRoute(
                    name: "APP",
                    areaName: "APP",
                  pattern: "{area:exists}/{controller=Account}/{action=LoginView}/{id?}");
                //endpoints.MapControllerRoute(
                //   name: "Admin",
                //   pattern: "{area:exists}/{controller=Account}/{action=LoginView}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
