using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseLayer.Repositories
{	public class IncomeDocumentRepository : IBaseRepository<IncomeDocument>
	{
		private readonly AppDbContext _context;

		public IncomeDocumentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(IncomeDocument entity)
		{
			await _context.IncomeDocuments.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<IncomeDocument> GetAll()
		{
			return _context.IncomeDocuments
				.Include(d => d.Items)
				.AsQueryable();
		}

		public async Task Delete(IncomeDocument entity)
		{
			_context.IncomeDocuments.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IncomeDocument> Update(IncomeDocument entity)
		{
			_context.IncomeDocuments.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
