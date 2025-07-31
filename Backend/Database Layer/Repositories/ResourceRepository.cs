using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseLayer.Repositories
{
	public class ResourceRepository : IBaseRepository<Resource>
	{
		private readonly AppDbContext _context;

		public ResourceRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(Resource entity)
		{
			await _context.Resources.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<Resource> GetAll()
		{
			return _context.Resources.AsQueryable();
		}

		public async Task Delete(Resource entity)
		{
			_context.Resources.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<Resource> Update(Resource entity)
		{
			_context.Resources.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}