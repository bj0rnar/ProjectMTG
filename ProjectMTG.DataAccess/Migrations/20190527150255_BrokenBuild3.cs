using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMTG.DataAccess.Migrations
{
    public partial class BrokenBuild3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckCards_Decks_DeckId",
                table: "DeckCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeckCards",
                table: "DeckCards");

            migrationBuilder.RenameTable(
                name: "DeckCards",
                newName: "DeckCard");

            migrationBuilder.RenameIndex(
                name: "IX_DeckCards_DeckId",
                table: "DeckCard",
                newName: "IX_DeckCard_DeckId");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                table: "DeckCard",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeckCard",
                table: "DeckCard",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCard_Decks_DeckId",
                table: "DeckCard",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckCard_Decks_DeckId",
                table: "DeckCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeckCard",
                table: "DeckCard");

            migrationBuilder.RenameTable(
                name: "DeckCard",
                newName: "DeckCards");

            migrationBuilder.RenameIndex(
                name: "IX_DeckCard_DeckId",
                table: "DeckCards",
                newName: "IX_DeckCards_DeckId");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                table: "DeckCards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeckCards",
                table: "DeckCards",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCards_Decks_DeckId",
                table: "DeckCards",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
