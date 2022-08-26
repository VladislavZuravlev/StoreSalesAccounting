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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCash = table.Column<int>(type: "int", nullable: false),
                    EmployeeNonCash = table.Column<int>(type: "int", nullable: false),
                    EmployeeOnlineCash = table.Column<int>(type: "int", nullable: false),
                    EmployeeTotalRevenue = table.Column<int>(type: "int", nullable: false),
                    EmployeeDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivingEmployee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Master = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MusicalInstrument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicalTask = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuitarCase = table.Column<bool>(type: "bit", nullable: false),
                    RepairEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiveAway = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ClientNumber",
                table: "Repairs",
                column: "ClientNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "StoreRevenues");
        }
    }
}
