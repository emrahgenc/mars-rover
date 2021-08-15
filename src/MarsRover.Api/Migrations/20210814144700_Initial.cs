using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MarsRover.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plateau",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size_Width = table.Column<int>(type: "int", nullable: true),
                    Size_Height = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plateau", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rover",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_Coordinate_X = table.Column<int>(type: "int", nullable: true),
                    Position_Coordinate_Y = table.Column<int>(type: "int", nullable: true),
                    Position_Direction = table.Column<int>(type: "int", nullable: true),
                    PlateauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rover", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plateau");

            migrationBuilder.DropTable(
                name: "Rover");
        }
    }
}
