using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMTG.DataAccess.Migrations
{
    public partial class Database_rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    DeckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeckName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.DeckId);
                    table.ForeignKey(
                        name: "FK_Decks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckCard",
                columns: table => new
                {
                    DeckCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeckId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_DeckCard", x => x.DeckCardId);
                    table.ForeignKey(
                        name: "FK_DeckCard_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "DeckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckCard_DeckId",
                table: "DeckCard",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_UserId",
                table: "Decks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "DeckCard");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
