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

		public CollectionContext(DbContextOptions<CollectionContext> options) : base(options) { }

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
			modelBuilder.Entity<DeckCardsDir>().HasKey(dc => new {dc.CardId, dc.DeckId});

		}

	}
}
