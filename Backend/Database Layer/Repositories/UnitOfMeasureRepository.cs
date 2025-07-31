namespace Backend.DatabaseLayer.Repositories
{
	public class UnitOfMeasureRepository : IBaseRepository<UnitOfMeasure>
	{
		private readonly AppDbContext _context;

		public UnitOfMeasureRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(UnitOfMeasure entity)
		{
			await _context.UnitOfMeasures.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<UnitOfMeasure> GetAll()
		{
			return _context.UnitOfMeasures.AsQueryable();
		}

		public async Task Delete(UnitOfMeasure entity)
		{
			_context.UnitOfMeasures.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<UnitOfMeasure> Update(UnitOfMeasure entity)
		{
			_context.UnitOfMeasures.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
