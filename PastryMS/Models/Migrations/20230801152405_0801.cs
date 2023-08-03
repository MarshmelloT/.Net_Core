using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class _0801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 32, nullable: true),
                    CategoryId = table.Column<string>(maxLength: 36, nullable: true),
                    ConsumableName = table.Column<string>(maxLength: 16, nullable: true),
                    Specification = table.Column<string>(maxLength: 32, nullable: true),
                    Num = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(maxLength: 8, nullable: true),
                    Money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarningNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableRecord",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ConsumableId = table.Column<string>(maxLength: 36, nullable: true),
                    Num = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Creator = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Refund_Instance",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    ModelId = table.Column<string>(maxLength: 36, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 64, nullable: true),
                    Reason = table.Column<string>(maxLength: 64, nullable: true),
                    Creator = table.Column<string>(maxLength: 36, nullable: true),
                    OuntNum = table.Column<int>(nullable: false),
                    OutGoodsId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Refund_Instance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Refund_InstanceStep",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    OrdersId = table.Column<string>(maxLength: 36, nullable: true),
                    ReviewerId = table.Column<string>(maxLength: 36, nullable: true),
                    ReviewReason = table.Column<string>(maxLength: 64, nullable: true),
                    ReviewStatus = table.Column<int>(nullable: false),
                    ReviewTime = table.Column<DateTime>(nullable: true),
                    BeforeStepId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Refund_InstanceStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Account = table.Column<string>(maxLength: 32, nullable: true),
                    Pwd = table.Column<string>(maxLength: 32, nullable: true),
                    CustomerName = table.Column<string>(maxLength: 50, nullable: true),
                    Sex = table.Column<string>(maxLength: 2, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DessertInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    DessertName = table.Column<string>(maxLength: 50, nullable: true),
                    DessertTypeId = table.Column<string>(maxLength: 36, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Num = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 36, nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DessertTypeInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    DessertTypeName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertTypeInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 32, nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Href = table.Column<string>(maxLength: 128, nullable: true),
                    ParentId = table.Column<string>(maxLength: 36, nullable: true),
                    Icon = table.Column<string>(maxLength: 32, nullable: true),
                    Target = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetailInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    DessertId = table.Column<string>(maxLength: 36, nullable: true),
                    Num = table.Column<int>(nullable: false),
                    Specification = table.Column<string>(maxLength: 32, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetailInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    OrdersDetailld = table.Column<string>(maxLength: 250, nullable: true),
                    CustomerId = table.Column<string>(maxLength: 36, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "R_RoleInfo_MenuInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<string>(maxLength: 36, nullable: true),
                    MenuId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_RoleInfo_MenuInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "R_UserInfo_RoleInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(maxLength: 36, nullable: true),
                    RoleId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_R_UserInfo_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    RoleName = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Account = table.Column<string>(maxLength: 32, nullable: true),
                    Pwd = table.Column<string>(maxLength: 32, nullable: true),
                    Description = table.Column<string>(maxLength: 32, nullable: true),
                    StaffName = table.Column<string>(maxLength: 16, nullable: true),
                    LeaderId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_Instance",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModelId = table.Column<string>(maxLength: 36, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 64, nullable: true),
                    Reason = table.Column<string>(maxLength: 64, nullable: true),
                    Creator = table.Column<string>(maxLength: 36, nullable: true),
                    OutNum = table.Column<int>(nullable: false),
                    OutGoodsId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_Instance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_InstanceStep",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    InstanceId = table.Column<string>(maxLength: 36, nullable: true),
                    ReviewerId = table.Column<string>(maxLength: 36, nullable: true),
                    ReviewReason = table.Column<string>(maxLength: 64, nullable: true),
                    ReviewStatus = table.Column<int>(nullable: false),
                    ReviewTime = table.Column<DateTime>(nullable: true),
                    BeforeStepId = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_InstanceStep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkFlow_Model",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DelTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 32, nullable: true),
                    Description = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkFlow_Model", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ConsumableInfo");

            migrationBuilder.DropTable(
                name: "ConsumableRecord");

            migrationBuilder.DropTable(
                name: "Customer_Refund_Instance");

            migrationBuilder.DropTable(
                name: "Customer_Refund_InstanceStep");

            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropTable(
                name: "DessertInfo");

            migrationBuilder.DropTable(
                name: "DessertTypeInfo");

            migrationBuilder.DropTable(
                name: "MenuInfo");

            migrationBuilder.DropTable(
                name: "OrdersDetailInfo");

            migrationBuilder.DropTable(
                name: "OrdersInfo");

            migrationBuilder.DropTable(
                name: "R_RoleInfo_MenuInfo");

            migrationBuilder.DropTable(
                name: "R_UserInfo_RoleInfo");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.DropTable(
                name: "StaffInfo");

            migrationBuilder.DropTable(
                name: "WorkFlow_Instance");

            migrationBuilder.DropTable(
                name: "WorkFlow_InstanceStep");

            migrationBuilder.DropTable(
                name: "WorkFlow_Model");
        }
    }
}
