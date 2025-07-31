using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using System.ComponentModel.DataAnnotations;
using static Backend.Database_Layer.Entities;

namespace Backend.DatabaseLayer
{
	public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {  }

		public DbSet<Resource> Resources { get; set; }
		public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<StockBalance> StockBalances { get; set; }
		public DbSet<IncomeDocument> IncomeDocuments { get; set; }
		public DbSet<IncomeDocumentItem> IncomeDocumentItems { get; set; }
		public DbSet<OutcomeDocument> OutcomeDocuments { get; set; }
		public DbSet<OutcomeDocumentItem> OutcomeDocumentItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Ресурс → единица измерения
			modelBuilder.Entity<Resource>()
				.HasOne(r => r.UnitOfMeasure)
				.WithMany()
				.HasForeignKey(r => r.UnitOfMeasureId)
				.IsRequired();

			// Документ поступления → ресурсы поступления
			modelBuilder.Entity<IncomeDocument>()
				.HasMany(d => d.Items)
				.WithOne(i => i.IncomeDocument)
				.HasForeignKey(i => i.IncomeDocumentId);

			// Документ отгрузки → клиент
			modelBuilder.Entity<OutcomeDocument>()
				.HasOne(d => d.Client)
				.WithMany()
				.HasForeignKey(d => d.ClientId);

			// Документ отгрузки → ресурсы отгрузки
			modelBuilder.Entity<OutcomeDocument>()
				.HasMany(d => d.Items)
				.WithOne(i => i.OutcomeDocument)
				.HasForeignKey(i => i.OutcomeDocumentId);

			// Ресурс поступления → ресурс
			modelBuilder.Entity<IncomeDocumentItem>()
				.HasOne(i => i.Resource)
				.WithMany()
				.HasForeignKey(i => i.ResourceId);

			// Ресурс отгрузки → ресурс
			modelBuilder.Entity<OutcomeDocumentItem>()
				.HasOne(i => i.Resource)
				.WithMany()
				.HasForeignKey(i => i.ResourceId);
		}
	}
}

