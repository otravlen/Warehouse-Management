using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseLayer.Repositories
{
	public class OutcomeDocumentItemRepository : IBaseRepository<OutcomeDocumentItem>
	{
		private readonly AppDbContext _context;

		public OutcomeDocumentItemRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(OutcomeDocumentItem entity)
		{
			await _context.OutcomeDocumentItems.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<OutcomeDocumentItem> GetAll()
		{
			return _context.OutcomeDocumentItems
				.Include(i => i.OutcomeDocument)
				.Include(i => i.Resource)
				.Include(i => i.UnitOfMeasure)
				.AsQueryable();
		}

		public async Task Delete(OutcomeDocumentItem entity)
		{
			_context.OutcomeDocumentItems.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<OutcomeDocumentItem> Update(OutcomeDocumentItem entity)
		{
			_context.OutcomeDocumentItems.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
