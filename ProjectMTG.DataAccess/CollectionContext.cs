using System;
using System.Data.SqlClient;

using Microsoft.EntityFrameworkCore;

using ProjectMTG.Model;

namespace ProjectMTG.DataAccess
{
	public class CollectionContext : DbContext
	{
		public DbSet<Card> Cards { get; set; }
		public DbSet<Deck> Decks { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<DeckCards> DeckCards { get; set; }

		public CollectionContext(DbContextOptions<CollectionContext> options) : base(options) { }

		public CollectionContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
			{
				DataSource = "(localdb)\\MSSQLLocalDB",
				InitialCatalog = "ProjectMTGDemoOneToManyVersionTwo",
				IntegratedSecurity = true
			};

			optionsBuilder.UseSqlServer(builder.ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/* Ska ikkje trenge detta
			modelBuilder.Entity<Deck>()
				.HasMany(c => c.Cards)
				.WithOne(d => d.deck);

			modelBuilder.Entity<Deck>()
				.HasOne(c => c.User)
				.WithMany(d => d.Decks)
				.HasForeignKey(x => x.UserId);
			*/

			modelBuilder.Entity<Deck>()
				.HasOne(c => c.User)
				.WithMany(x => x.Decks)
				.HasForeignKey(x => x.DeckId);

			modelBuilder.Entity<Deck>()
				.HasMany(x => x.Cards)
				.WithOne(z => z.deck)
				.HasForeignKey(x => x.DeckCardId);


			//Støttemodell
			modelBuilder.Entity<DeckCards>()
				.Property(e => e.colors)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

			modelBuilder.Entity<DeckCards>()
				.Property(e => e.subtype)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

			modelBuilder.Entity<DeckCards>()
				.Property(e => e.supertype)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

			modelBuilder.Entity<DeckCards>()
				.Property(e => e.types)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

			//Basemodell
			modelBuilder.Entity<Card>()
				.Property(e => e.colors)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries));

			modelBuilder.Entity<Card>()
				.Property(e => e.subtype)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

			modelBuilder.Entity<Card>()
				.Property(e => e.supertype)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

			modelBuilder.Entity<Card>()
				.Property(e => e.types)
				.HasConversion(
					v => string.Join(";", v),
					v => v.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

		}

	}
}
