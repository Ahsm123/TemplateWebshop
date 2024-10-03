using Microsoft.AspNetCore.Mvc;
using Webshop.API.DAL.Interfaces;
using Webshop.API.DAL.Models;

namespace Webshop.API.Controllers;

[ApiController]
[Route(baseURI)]
public class ProductsController : ControllerBase
{
	const string baseURI = "api/v1/[controller]";
	private IProductDAO _productDAO;

	public ProductsController(IProductDAO productDAO)
	{
		_productDAO = productDAO;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Product>>> GetAll()
	{
		var products = await _productDAO.GetAll();
		return Ok(products);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Product>> GetUsingId(int id)
	{
		var product = await _productDAO.Get(id);
		if (product == null)
		{
			return NotFound();
		}
		return Ok(product);
	}

	[HttpPost]
	public async Task<ActionResult<int>> AddProduct([FromBody] Product product)
	{
		product.Id = await _productDAO.Insert(product);

		return Created($"{baseURI}/{product.Id}", product);
	}

	[HttpPut]
	public async Task<ActionResult<bool>> Put(Product product)
	{
		var isUpdated = await _productDAO.Update(product);
		if (!isUpdated)
		{
			return NotFound();
		}
		return Ok();
	}

	[HttpDelete]
	public async Task<ActionResult<bool>> Delete(int id)
	{
		var isDeleted = await _productDAO.Delete(id);
		if (!isDeleted)
		{
			return NotFound();
		}
		return Ok();
	}

	[HttpGet("category/{id}")]
	public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int id)
	{
		var products = await _productDAO.GetProductsByCategory(id);
		return Ok(products);
	}
}
