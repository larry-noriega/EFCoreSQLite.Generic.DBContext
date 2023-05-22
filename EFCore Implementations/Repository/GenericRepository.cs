using EFCore_Implementations.Context;
using EFCore_Implementations.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCore_Implementations.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
		where T : class, IKeyedModel, new()
	{
		private readonly GenericDBContext<T> _context;

		public GenericRepository(IOptions<SQLiteSettings>? options)
		{
			_context = new(options);
		}

		public async Task<T?> Get(int? id)
		{
			if (id is null) return default;

			return await _context.Items
				.FirstOrDefaultAsync(doc => doc.Id == id);
		}

		public async Task<IEnumerable<T?>> List()
		{
			return await _context.Items
				.ToListAsync();
		}

		public async Task<int> Insert(T document)
		{
			_context.Items.Add(document);			
			return await _context.SaveChangesAsync();
		}

		public async Task<T?> Update(T? document)
		{
			if (document is null) return null;

			var content = _context.Items.Update(document);

			if (content.State is EntityState.Modified) await _context.SaveChangesAsync();	

			return document;
		}

		public async Task<int?> Delete(int? id)
		{
			if (id is null) return null;

			T? item =
				await _context.Items.FirstOrDefaultAsync(doc => doc.Id == id);

			if (item is null) return null;

			_context.Items.Remove(item);

			return await _context.SaveChangesAsync();
		}

	}
}
