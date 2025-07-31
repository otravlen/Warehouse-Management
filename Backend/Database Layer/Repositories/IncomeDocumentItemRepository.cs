using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseLayer.Repositories
{
	public class IncomeDocumentItemRepository : IBaseRepository<IncomeDocumentItem>
	{
		private readonly AppDbContext _context;

		public IncomeDocumentItemRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(IncomeDocumentItem entity)
		{
			await _context.IncomeDocumentItems.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<IncomeDocumentItem> GetAll()
		{
			return _context.IncomeDocumentItems
				.Include(i => i.IncomeDocument)
				.Include(i => i.Resource)
				.Include(i => i.UnitOfMeasure)
				.AsQueryable();
		}

		public async Task Delete(IncomeDocumentItem entity)
		{
			_context.IncomeDocumentItems.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IncomeDocumentItem> Update(IncomeDocumentItem entity)
		{
			_context.IncomeDocumentItems.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
