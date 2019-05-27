using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMTG.DataAccess.Migrations
{
    public partial class BrokenBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Decks_DeckId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_DeckId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "DeckCards",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeckId = table.Column<int>(nullable: true),
                    artist = table.Column<string>(nullable: true),
                    colors = table.Column<string>(nullable: true),
                    convertedManaCost = table.Column<float>(nullable: false),
                    loyalty = table.Column<string>(nullable: true),
                    manaCost = table.Column<string>(nullable: true),
                    multiverseId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    number = table.Column<string>(nullable: true),
                    rarity = table.Column<string>(nullable: true),
                    scryfallId = table.Column<string>(nullable: true),
                    scryfallIllustrationId = table.Column<string>(nullable: true),
                    scryfallOracleId = table.Column<string>(nullable: true),
                    subtype = table.Column<string>(nullable: true),
                    supertype = table.Column<string>(nullable: true),
                    tcgplayerProductId = table.Column<int>(nullable: false),
                    tcgplayerPurchaseUrl = table.Column<string>(nullable: true),
                    text = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    types = table.Column<string>(nullable: true),
                    uuid = table.Column<string>(nullable: true),
                    uuidV421 = table.Column<string>(nullable: true),
                    power = table.Column<string>(nullable: true),
                    toughness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_DeckCards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_DeckId",
                table: "DeckCards",
                column: "DeckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckCards");

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId",
                table: "Cards",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Decks_DeckId",
                table: "Cards",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "DeckId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
