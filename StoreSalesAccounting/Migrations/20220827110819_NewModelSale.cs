using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreSalesAccounting.Migrations
{
    public partial class NewModelSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cash = table.Column<int>(type: "int", nullable: false),
                    NonCash = table.Column<int>(type: "int", nullable: false),
                    OnlineCash = table.Column<int>(type: "int", nullable: false),
                    TotalRevenue = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
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
                    GuitarCase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiveAway = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaleAmount = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ClientNumber",
                table: "Repairs",
                column: "ClientNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "StoreRevenues");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
