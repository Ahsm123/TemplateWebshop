using Webshop.API.DAL.Interfaces;
using Webshop.API.DAL.Models;

namespace Webshop.API.DAL.DAO
{
	public class ProductDAO : IProductDAO
	{
		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Product?> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Product>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<int> Insert(Product t)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Product t)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
		{
			throw new NotImplementedException();
		}
	}
}
