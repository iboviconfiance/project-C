using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        double shipping = _customer.LivesInUSA() ? 5 : 35;
        return total + shipping;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder("📦 Packing Label:\n");
        foreach (Product p in _products)
        {
            label.AppendLine(" - " + p.GetLabel());
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder("🚚 Shipping Label:\n");
        label.AppendLine(_customer.GetName());
        label.AppendLine(_customer.GetAddress().GetFullAddress());
        return label.ToString();
    }
}
