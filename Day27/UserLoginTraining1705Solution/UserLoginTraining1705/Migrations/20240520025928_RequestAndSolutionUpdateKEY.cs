using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserLoginTraining1705.Migrations
{
    public partial class RequestAndSolutionUpdateKEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "solutions",
                newName: "RequestID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "requests",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "solutions",
                newName: "RequestId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "requests",
                newName: "UserID");
        }
    }
}
