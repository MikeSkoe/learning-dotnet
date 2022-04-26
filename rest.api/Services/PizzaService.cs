using rest.api.Models;

namespace rest.api.Services;

public class PizzaService {
	private List<Pizza> Pizzas { get; }
	public int newId = 3;

	public PizzaService() {
		Pizzas = new List<Pizza> {
			new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
			new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true },
		};
	}

	public List<Pizza> GetAll() => Pizzas;

	public Pizza? Get(int id) => Pizzas.FirstOrDefault(pizza => pizza.Id == id);

	public void Add(Pizza pizza) {
		pizza.Id = newId++;
		Pizzas.Add(pizza);
	}

	public void Delete(int id) {
		var pizza = Get(id);

		if (pizza is null) return;

		Pizzas.Remove(pizza);
	}

	public void Update(Pizza pizza) {
		var index = Pizzas.FindIndex(_pizza => _pizza.Id == pizza.Id);

		if (index < 0) return;

		Pizzas[index] = pizza;
	}

}