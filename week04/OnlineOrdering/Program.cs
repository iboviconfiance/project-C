using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== ONLINE ORDERING SYSTEM =====\n");

        // Order 1
        Address addr1 = new Address("123 Main St", "Boise", "ID", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "LPT-001", 999.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MSE-042", 25.50, 2));

        // Order 2
        Address addr2 = new Address("26 Rue Kedzoua Carrefour", "Kintele", "Brazzaville", "Republic of Congo");
        Customer cust2 = new Customer("Confiance Ibovi Hategekimana", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Bluetooth Speaker", "SPK-212", 75.99, 1));
        order2.AddProduct(new Product("Smart Watch", "WTCH-300", 150.00, 1));
        order2.AddProduct(new Product("Phone Case", "CASE-115", 12.99, 3));

        // Display orders
        DisplayOrder(order1);
        Console.WriteLine("\n--------------------------------------------\n");
        DisplayOrder(order2);

        Console.WriteLine("\n===== END OF PROGRAM =====");
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"💰 Total Price: ${order.GetTotalCost():0.00}");
    }
}
