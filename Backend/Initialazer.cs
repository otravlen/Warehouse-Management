using Backend.DatabaseLayer.Repositories;
using Backend.DatabaseLayer;

namespace Backend
{
	public static class Initialazer	{
		public static void RegisterRepositories(this IServiceCollection services)
		{
			services.AddScoped<IBaseRepository<Resource>, ResourceRepository>();
			services.AddScoped<IBaseRepository<UnitOfMeasure>, UnitOfMeasureRepository>();
			services.AddScoped<IBaseRepository<Client>, ClientRepository>();
			services.AddScoped<IBaseRepository<StockBalance>, StockBalanceRepository>();
			services.AddScoped<IBaseRepository<IncomeDocument>, IncomeDocumentRepository>();
			services.AddScoped<IBaseRepository<IncomeDocumentItem>, IncomeDocumentItemRepository>();
			services.AddScoped<IBaseRepository<OutcomeDocument>, OutcomeDocumentRepository>();
			services.AddScoped<IBaseRepository<OutcomeDocumentItem>, OutcomeDocumentItemRepository>();
		}
	}
}
