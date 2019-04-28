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
		public DbSet<DeckCardsDir> DeckCardsDirs { get; set; }

		public CollectionContext(DbContextOptions<CollectionContext> options) : base(options) { }

		public CollectionContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
			{
				DataSource = "(localdb)\\MSSQLLocalDB",
				InitialCatalog = "ProjectMTGDemo",
				IntegratedSecurity = true
			};

			optionsBuilder.UseSqlServer(builder.ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//wat?
			modelBuilder.Entity<User>().HasData(new User() {UserId = 1, UserName = "Jell", Decks = null});

			modelBuilder.Entity<DeckCardsDir>().HasKey(dc => new {dc.CardId, dc.DeckId});

			modelBuilder.Entity<DeckCardsDir>()
				.HasOne<Deck>(d => d.Deck)
				.WithMany(s => s.Contains)
				.HasForeignKey(c => c.DeckId);

			modelBuilder.Entity<DeckCardsDir>()
				.HasOne<Card>(c => c.Card)
				.WithMany(r => r.InCollection)
				.HasForeignKey(r => r.CardId);

			modelBuilder.Entity<User>()
				.HasMany(d => d.Decks)
				.WithOne(u => u.User)
				.IsRequired();

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
