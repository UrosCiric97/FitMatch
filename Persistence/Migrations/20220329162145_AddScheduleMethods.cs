using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddScheduleMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerAvailableSessions_Session_TrainerId",
                table: "TrainerAvailableSessions");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerAvailableSessions_SessionId",
                table: "TrainerAvailableSessions",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerAvailableSessions_Session_SessionId",
                table: "TrainerAvailableSessions",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerAvailableSessions_Session_SessionId",
                table: "TrainerAvailableSessions");

            migrationBuilder.DropIndex(
                name: "IX_TrainerAvailableSessions_SessionId",
                table: "TrainerAvailableSessions");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerAvailableSessions_Session_TrainerId",
                table: "TrainerAvailableSessions",
                column: "TrainerId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
