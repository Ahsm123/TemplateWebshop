using Microsoft.AspNetCore.Mvc;
using Webshop.API.DAL.Interfaces;
using Webshop.API.DAL.Models;

namespace Webshop.API.Controllers;

[ApiController]
[Route(baseURI)]
public class CategoriesController : ControllerBase
{
	const string baseURI = "api/v1/[controller]";
	private ICategoryDAO _categoryDAO;

	public CategoriesController(ICategoryDAO categoryDAO)
	{
		_categoryDAO = categoryDAO;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Category>>> GetAll()
	{
		var accounts = await _categoryDAO.GetAll();
		return Ok(accounts);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Category>> GetUsingId(int id)
	{
		var category = await _categoryDAO.Get(id);
		if (category == null)
		{
			return NotFound();
		}
		return Ok(category);
	}

	[HttpPost]
	public async Task<ActionResult<int>> AddCategory([FromBody] Category category)
	{
		category.Id = await _categoryDAO.Insert(category);

		return Created($"{baseURI}/{category.Id}", category);
	}

	[HttpPut]
	public async Task<ActionResult<bool>> Put(Category category)
	{
		var isUpdated = await _categoryDAO.Update(category);
		if (!isUpdated)
		{
			return NotFound();
		}
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult<bool>> Delete(int id)
	{
		var isDeleted = await _categoryDAO.Delete(id);
		if (!isDeleted)
		{

			return NotFound();

		}

		return Ok();
	}
}
