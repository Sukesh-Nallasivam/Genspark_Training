using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserLoginTraining1705.Migrations
{
    public partial class RequestAndSolutionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<bool>(type: "bit", nullable: false),
                    SolutionAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "solutions",
                columns: table => new
                {
                    SolutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionBy = table.Column<int>(type: "int", nullable: false),
                    SolutionGivenTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solutions", x => x.SolutionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requests");

            migrationBuilder.DropTable(
                name: "solutions");
        }
    }
}
