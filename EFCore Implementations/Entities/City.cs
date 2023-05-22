using EFCore_Implementations.Interfaces;

namespace EFCore_Implementations.Entities
{
	public class City
	{
		public int Id { get; set; }
		public string? Name { get; internal set; }
	}
}
