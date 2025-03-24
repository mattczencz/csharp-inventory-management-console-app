namespace InventoryManagement.Classes;

public class Inventory
{
    public readonly List<Product> Products = new List<Product>();

    public bool AddProduct(string name, double price, int quantity)
    {
        if (Products.Exists(product => product.Name.ToLower() == name.ToLower()))
        {
            Console.WriteLine($"{name} is already in the inventory. Please update or remove it to alter the info.");
            return false;
        }
        
        Products.Add(new Product(name, price, quantity));
        Console.WriteLine($"{name} has been added to your inventory.");
        return true;
    }

    public bool RemoveProduct(string name)
    {
        Product? product = Products.Find(p => p.Name.ToLower() == name.ToLower());

        if (product == null)
        {
            Console.WriteLine("Could not find product to remove. Please try again.");
            return false;
        }

        Products.Remove(product);
        Console.WriteLine($"{name} has been removed from the inventory.");
        return true;
    }

    public bool UpdateProduct(string name, double? price, int? quantity)
    {
        Product? product = Products.Find(p => p.Name.ToLower() == name.ToLower());
        
        if (product == null)
        {
            Console.WriteLine("Could not find product to update. Please try again.");
            return false;
        }

        if (price == null && quantity == null)
        {
            Console.WriteLine($"Unable to update {name}. Please check values entered and try again.");
            return false;
        }

        product.Price = price ?? product.Price;
        product.Quantity = quantity ?? product.Quantity;
        Console.WriteLine($"{name} was updated successfully.");
        return true;
    }

    public void ListInventory()
    {
        Console.WriteLine("================== Inventory Report ==================");

        if (Products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            Console.WriteLine("----------------------------------------------------------------------");
            return;
        }
        
        foreach (var product in Products)
        {
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");
            Console.WriteLine($"Quantity: {product.Quantity}");
            Console.WriteLine("----------------------------------------------------------------------");
        }
    }
}