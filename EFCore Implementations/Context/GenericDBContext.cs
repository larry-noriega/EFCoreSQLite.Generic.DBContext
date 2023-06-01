// Ignore Spelling: Db

using EFCore_Implementations.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace EFCore_Implementations.Context
{
	public class GenericDBContext<TClass>
		: DbContext
		where TClass : class, IKeyedModel, new()
	{
		public DbSet<TClass> Items { get; set; } = default!;

		private readonly IOptions<SQLiteSettings>? _options;

		public GenericDBContext(IOptions<SQLiteSettings>? options)
		{
			_options = options;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			if (_options is null)
				throw new ArgumentNullException("Invalid settings", nameof(_options.Value.ConnectionString));

			optionsBuilder.UseSqlite(_options.Value.ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			EntityTypeBuilder<TClass>? model = modelBuilder.Entity<TClass>();			

			modelBuilder.Entity<TClass>().ToTable(model.Metadata.ClrType.Name.ToLower());
		}
	}
}
