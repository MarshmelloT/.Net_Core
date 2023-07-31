using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Xml;

namespace Models
{
    public class PastryMSDB : DbContext
    {
        public PastryMSDB()
        {
        }

        public PastryMSDB(DbContextOptions<PastryMSDB> options) : base(options)
        {
        }


        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ConsumableInfo> ConsumableInfo { get; set; }
        public virtual DbSet<ConsumableRecord> ConsumableRecord { get; set; }
        public virtual DbSet<Customer_Refund_InstanceStep> Customer_Refund_InstanceStep { get; set; }
        public virtual DbSet<DessertInfo> DessertInfo { get; set; }
        public virtual DbSet<DessertTypeInfo> DessertTypeInfo { get; set; }
        public virtual DbSet<MenuInfo> MenuInfo { get; set; }
        public virtual DbSet<OrdersDetailInfo> OrdersDetailInfo { get; set; }
        public virtual DbSet<R_RoleInfo_MenuInfo> R_RoleInfo_MenuInfo { get; set; }
        public virtual DbSet<R_UserInfo_RoleInfo> R_UserInfo_RoleInfo { get; set; }
        public virtual DbSet<RoleInfo> RoleInfo { get; set; }
        public virtual DbSet<WorkFlow_Instance> WorkFlow_Instance { get; set; }
        public virtual DbSet<WorkFlow_InstanceStep> WorkFlow_InstanceStep { get; set; }
        public virtual DbSet<WorkFlow_Model> WorkFlow_Model { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}