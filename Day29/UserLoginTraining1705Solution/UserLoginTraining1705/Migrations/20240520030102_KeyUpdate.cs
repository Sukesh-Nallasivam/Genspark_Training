using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserLoginTraining1705.Migrations
{
    public partial class KeyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_solutions_RequestID",
                table: "solutions",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_requests_UserId",
                table: "requests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_requests_users_UserId",
                table: "requests",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_solutions_requests_RequestID",
                table: "solutions",
                column: "RequestID",
                principalTable: "requests",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requests_users_UserId",
                table: "requests");

            migrationBuilder.DropForeignKey(
                name: "FK_solutions_requests_RequestID",
                table: "solutions");

            migrationBuilder.DropIndex(
                name: "IX_solutions_RequestID",
                table: "solutions");

            migrationBuilder.DropIndex(
                name: "IX_requests_UserId",
                table: "requests");
        }
    }
}
