using Microsoft.AspNetCore.Mvc;
using rest.api.Services;
using rest.api.Models;

namespace rest.api.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase {
	private PizzaService _pizzaService = new PizzaService();

	[HttpGet]
	public ActionResult<List<Pizza>> GetAll() => _pizzaService.GetAll();

	[HttpGet("{id}")]
	public ActionResult<Pizza> Get(int id) {
		var pizza = _pizzaService.Get(id);

		if (pizza is null) return NotFound();

		return pizza;
	}

	[HttpPost]
	public IActionResult Create(Pizza pizza) {
		_pizzaService.Add(pizza);

		return CreatedAtAction(nameof(Create), new { Id = pizza.Id }, pizza);
	}

	[HttpPut("{id}")]
	public IActionResult Update(int id, Pizza pizza) {
		if (id != pizza.Id) return BadRequest();

		var existingPizza = _pizzaService.Get(id);

		if (existingPizza is null) return NotFound();

		_pizzaService.Update(pizza);

		return NoContent();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(int id) {
		var existingPizza = _pizzaService.Get(id);

		if (existingPizza is null) return NotFound();

		_pizzaService.Delete(id);

		return NoContent();
	}
}
