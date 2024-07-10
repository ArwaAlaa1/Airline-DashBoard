using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLine.Migrations
{
    public partial class phoneandqualify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLinesPhones",
                columns: table => new
                {
                    Phones = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLinesPhones", x => new { x.AirLineId, x.Phones });
                    table.ForeignKey(
                        name: "FK_AirLinesPhones_AirLine_Companies_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLine_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpQualifications",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpQualifications", x => new { x.EmployeeId, x.Qualification });
                    table.ForeignKey(
                        name: "FK_EmpQualifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirLinesPhones");

            migrationBuilder.DropTable(
                name: "EmpQualifications");
        }
    }
}
