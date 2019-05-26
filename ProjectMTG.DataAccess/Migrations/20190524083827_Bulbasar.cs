using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMTG.DataAccess.Migrations
{
    public partial class Bulbasar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckCards_Users_UserId",
                table: "DeckCards");

            migrationBuilder.DropIndex(
                name: "IX_DeckCards_UserId",
                table: "DeckCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DeckCards");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Decks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_UserId",
                table: "Decks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Users_UserId",
                table: "Decks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Users_UserId",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_UserId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Decks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DeckCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_UserId",
                table: "DeckCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCards_Users_UserId",
                table: "DeckCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
