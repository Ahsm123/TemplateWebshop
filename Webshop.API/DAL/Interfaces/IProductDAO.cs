using Webshop.API.DAL.Models;

namespace Webshop.API.DAL.Interfaces
{
	public interface IProductDAO : IDAO<Product>
	{
		Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
	}
}
