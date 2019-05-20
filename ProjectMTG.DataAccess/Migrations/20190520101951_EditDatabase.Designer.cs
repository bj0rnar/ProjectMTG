﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMTG.DataAccess;

namespace ProjectMTG.DataAccess.Migrations
{
    [DbContext(typeof(CollectionContext))]
    [Migration("20190520101951_EditDatabase")]
    partial class EditDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectMTG.Model.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeckId");

                    b.Property<string>("artist");

                    b.Property<string>("colors");

                    b.Property<float>("convertedManaCost");

                    b.Property<string>("loyalty");

                    b.Property<string>("manaCost");

                    b.Property<int>("multiverseId");

                    b.Property<string>("name");

                    b.Property<string>("number");

                    b.Property<string>("power");

                    b.Property<string>("rarity");

                    b.Property<string>("scryfallId");

                    b.Property<string>("scryfallIllustrationId");

                    b.Property<string>("scryfallOracleId");

                    b.Property<string>("subtype");

                    b.Property<string>("supertype");

                    b.Property<int>("tcgplayerProductId");

                    b.Property<string>("tcgplayerPurchaseUrl");

                    b.Property<string>("text");

                    b.Property<string>("toughness");

                    b.Property<string>("type");

                    b.Property<string>("types");

                    b.Property<string>("uuid");

                    b.Property<string>("uuidV421");

                    b.HasKey("CardId");

                    b.HasIndex("DeckId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("ProjectMTG.Model.Deck", b =>
                {
                    b.Property<int>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeckName");

                    b.Property<int>("UserId");

                    b.HasKey("DeckId");

                    b.HasIndex("UserId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("ProjectMTG.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectMTG.Model.Card", b =>
                {
                    b.HasOne("ProjectMTG.Model.Deck", "deck")
                        .WithMany("Cards")
                        .HasForeignKey("DeckId");
                });

            modelBuilder.Entity("ProjectMTG.Model.Deck", b =>
                {
                    b.HasOne("ProjectMTG.Model.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
