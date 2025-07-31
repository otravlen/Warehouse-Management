using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseLayer.Repositories
{
	public class StockBalanceRepository : IBaseRepository<StockBalance>
	{
		private readonly AppDbContext _context;

		public StockBalanceRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(StockBalance entity)
		{
			await _context.StockBalances.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<StockBalance> GetAll()
		{
			return _context.StockBalances
				.Include(s => s.Resource)
				.Include(s => s.UnitOfMeasure)
				.AsQueryable();
		}

		public async Task Delete(StockBalance entity)
		{
			_context.StockBalances.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<StockBalance> Update(StockBalance entity)
		{
			_context.StockBalances.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
