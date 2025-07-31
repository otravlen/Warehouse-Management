using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseLayer.Repositories
{
	public class OutcomeDocumentRepository : IBaseRepository<OutcomeDocument>
	{
		private readonly AppDbContext _context;

		public OutcomeDocumentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(OutcomeDocument entity)
		{
			await _context.OutcomeDocuments.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<OutcomeDocument> GetAll()
		{
			return _context.OutcomeDocuments
				.Include(d => d.Client)
				.Include(d => d.Items)
				.AsQueryable();
		}

		public async Task Delete(OutcomeDocument entity)
		{
			_context.OutcomeDocuments.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<OutcomeDocument> Update(OutcomeDocument entity)
		{
			_context.OutcomeDocuments.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
