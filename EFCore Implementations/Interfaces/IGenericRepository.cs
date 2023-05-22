namespace EFCore_Implementations.Interfaces
{
    public interface IGenericRepository<T> where T : class, IKeyedModel
	{
		public Task<T?> Get(int? id);
		public Task<int> Insert(T document);
		public Task<T?> Update(T? document);
		public Task<int?> Delete(int? id);
		Task<IEnumerable<T?>> List();
	}
}