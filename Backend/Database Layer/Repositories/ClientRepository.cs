namespace Backend.DatabaseLayer.Repositories
{
	public class ClientRepository : IBaseRepository<Client>
	{
		private readonly AppDbContext _context;

		public ClientRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task Create(Client entity)
		{
			await _context.Clients.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public IQueryable<Client> GetAll()
		{
			return _context.Clients.AsQueryable();
		}

		public async Task Delete(Client entity)
		{
			_context.Clients.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<Client> Update(Client entity)
		{
			_context.Clients.Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
