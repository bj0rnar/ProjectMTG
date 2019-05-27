using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMTG.DataAccess.Migrations
{
    public partial class Database_versjon_tre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeckCard_Decks_DeckCardId",
                table: "DeckCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Users_DeckId",
                table: "Decks");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                table: "Decks",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Decks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeckCardId",
                table: "DeckCard",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "DeckCard",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decks_UserId",
                table: "Decks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckCard_DeckId",
                table: "DeckCard",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCard_Decks_DeckId",
                table: "DeckCard",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_DeckCard_Decks_DeckId",
                table: "DeckCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Decks_Users_UserId",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_Decks_UserId",
                table: "Decks");

            migrationBuilder.DropIndex(
                name: "IX_DeckCard_DeckId",
                table: "DeckCard");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "DeckCard");

            migrationBuilder.AlterColumn<int>(
                name: "DeckId",
                table: "Decks",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "DeckCardId",
                table: "DeckCard",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCard_Decks_DeckCardId",
                table: "DeckCard",
                column: "DeckCardId",
                principalTable: "Decks",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decks_Users_DeckId",
                table: "Decks",
                column: "DeckId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
