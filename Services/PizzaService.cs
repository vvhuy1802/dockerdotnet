using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza Pizza)
    {
        Pizza.Id = nextId++;
        Pizzas.Add(Pizza);
    }

    public static void Delete(int id)
    {
        var Pizza = Get(id);
        if(Pizza is null)
            return;

        Pizzas.Remove(Pizza);
    }

    public static void Update(Pizza Pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == Pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = Pizza;
    }

    public static void DeleteAll() {
        Pizzas.Clear();
    }
}