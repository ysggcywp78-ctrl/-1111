using System;

public class Order
{
    public string Id { get; set; }
    public string ItemName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }


    public Order(string id, string itemName, decimal price, int quantity)
    {
        Id = id;
        ItemName = itemName;
        Price = price;
        Quantity = quantity;
    }
    public Order() : this("UNKNOWN", "Продукты", 0.0m, 1)
    {
    }

    public Order(string id, string itemName, decimal price) : this(id, itemName, price, 1)
    {
    }

    public void Deconstruct(out string itemName, out decimal price, out int quantity)
    {
        itemName = ItemName;
        price = Price;
        quantity = Quantity;
    }
}

public class Program
{
    public static void Main()
    {

        Order order1 = new Order();

        Order order2 = new Order("A-102", "Беспроводные наушники", 4500.50m);

        Order order3 = new Order("B-205", "Книга по C#", 1200.00m, 3);

        Order order4 = new Order() { ItemName = "Кофе в зернах", Price = 850.75m };

        Console.WriteLine("--- Созданные заказы ---");
        PrintOrder(order1);
        PrintOrder(order2);
        PrintOrder(order3);
        PrintOrder(order4);


        Console.WriteLine("\n--- Тест деконструктора для order3 ---");
        var (name, price, qty) = order3;
        Console.WriteLine($"Деконструированные данные: Товар = {name}, Цена = {price}, Количество = {qty}");
    }

    private static void PrintOrder(Order order)
    {
        Console.WriteLine($"ID: {order.Id}, Товар: {order.ItemName}, Цена: {order.Price}, Кол-во: {order.Quantity}");
    }
}