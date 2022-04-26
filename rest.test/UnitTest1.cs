using NUnit.Framework;
using rest.api.Services;
using rest.api.Models;

namespace rest.test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var pizzaService = new PizzaService();

        pizzaService.Add(new Pizza {
            Id = 1,
            Name = "CustomName",
            IsGlutenFree = true,
        });

        Assert.AreEqual(pizzaService.GetAll().Count, 3);
    }

    [Test]
    public void Test2()
    {
        var pizzaService = new PizzaService();

        Assert.AreEqual(pizzaService.GetAll().Count, 2);
    }

}