using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public string Description { get; private set; }

    public Item(string name, double price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    public string GetItemDetails()
    {
        return $"{Name} - ${Price} | {Description}";
    }
}


public class Cart
{
    private List<Item> items;

    public Cart()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Console.WriteLine($"Added: {item.Name} to the cart.");
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"Removed: {item.Name} from the cart.");
        }
        else
        {
            Console.WriteLine($"Item not found in the cart: {item.Name}");
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var item in items)
        {
            total += item.Price;
        }
        return total;
    }

    public List<Item> GetItems()
    {
        return new List<Item>(items); // Return a copy to maintain encapsulation
    }
}

public class Order
{
    public List<Item> OrderItems { get; private set; }
    public double OrderTotal { get; private set; }

    public Order(List<Item> items, double total)
    {
        OrderItems = items;
        OrderTotal = total;
    }

    public void FinalizeOrder()
    {
        Console.WriteLine("Order finalized successfully!");
        Console.WriteLine("Order Summary:");
        foreach (var item in OrderItems)
        {
            Console.WriteLine(item.GetItemDetails());
        }
        Console.WriteLine($"Total: ${OrderTotal}");
    }
}

public class PaymentProcessor
{
    public string PaymentMethod { get; set; }

    public PaymentProcessor(string paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Processing {PaymentMethod} payment for ${amount}...");
        Console.WriteLine("Payment successful!");
    }
}

public class OnlineStore
{
    private Cart cart;

    public OnlineStore()
    {
        cart = new Cart();
    }

    public void AddItemToCart(Item item)
    {
        cart.AddItem(item);
    }

    public void RemoveItemFromCart(Item item)
    {
        cart.RemoveItem(item);
    }

    public void Checkout()
    {
        double total = cart.CalculateTotal();
        if (total == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return;
        }

        Console.WriteLine($"Your total is ${total}. Please select a payment method (Card/Paypal):");
        string method = Console.ReadLine();

        PaymentProcessor paymentProcessor = new PaymentProcessor(method);
        paymentProcessor.ProcessPayment(total);

        Order order = new Order(cart.GetItems(), total);
        order.FinalizeOrder();
    }
}


class Program
{
    static void Main(string[] args)
    {
        OnlineStore store = new OnlineStore();

        // Example items
        Item item1 = new Item("Laptop", 999.99, "High performance laptop");
        Item item2 = new Item("Headphones", 199.99, "Noise cancelling headphones");

        // Simulate shopping
        store.AddItemToCart(item1);
        store.AddItemToCart(item2);

        Console.WriteLine("\nWould you like to remove any item? Enter the name or type 'no':");
        string response = Console.ReadLine();

        if (response.ToLower() != "no")
        {
            if (response.ToLower() == item1.Name.ToLower())
                store.RemoveItemFromCart(item1);
            else if (response.ToLower() == item2.Name.ToLower())
                store.RemoveItemFromCart(item2);
            else
                Console.WriteLine("Item not recognized.");
        }

        // Checkout
        store.Checkout();
    }
}
