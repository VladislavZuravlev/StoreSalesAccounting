using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreSalesAccounting.Migrations
{
    public partial class StringNumberClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ClientNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repairs");
        }
    }
}
