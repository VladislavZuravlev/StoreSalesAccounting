using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreSalesAccounting.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCash = table.Column<int>(type: "int", nullable: false),
                    EmployeeNonCash = table.Column<int>(type: "int", nullable: false),
                    EmployeeOnlineCash = table.Column<int>(type: "int", nullable: false),
                    EmployeeTotalRevenue = table.Column<int>(type: "int", nullable: false),
                    EmployeeDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "StoreRevenues",
                columns: table => new
                {
                    StoreRevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreCash = table.Column<int>(type: "int", nullable: false),
                    StoreNonCash = table.Column<int>(type: "int", nullable: false),
                    StoreOnlineCash = table.Column<int>(type: "int", nullable: false),
                    StoreTotalRevenue = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRevenues", x => x.StoreRevenueId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "StoreRevenues");
        }
    }
}
