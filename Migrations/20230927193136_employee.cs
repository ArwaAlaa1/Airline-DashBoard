using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirLine.Migrations
{
    public partial class employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Road_Crafts",
                table: "Road_Crafts");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Road_Crafts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Road_Crafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Road_Crafts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisable",
                table: "Road_Crafts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Road_Crafts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Road_Crafts",
                table: "Road_Crafts",
                columns: new[] { "AirCraftId", "RouteId", "DepatureTime" });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BDDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BDMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BDYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirLineId = table.Column<int>(type: "int", nullable: false),
                    IsVisable = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AirLine_Companies_AirLineId",
                        column: x => x.AirLineId,
                        principalTable: "AirLine_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AirLineId",
                table: "Employees",
                column: "AirLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Road_Crafts",
                table: "Road_Crafts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Road_Crafts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Road_Crafts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Road_Crafts");

            migrationBuilder.DropColumn(
                name: "IsVisable",
                table: "Road_Crafts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Road_Crafts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Road_Crafts",
                table: "Road_Crafts",
                columns: new[] { "AirCraftId", "RouteId" });
        }
    }
}
