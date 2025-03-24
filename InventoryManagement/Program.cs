using InventoryManagement.Classes;

bool running = true;
Inventory inventory = new Inventory();

Console.WriteLine("Hello! Welcome to your inventory management tool.");
Console.WriteLine("What would you like to do? Please enter the number of the action.");

do
{
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Update Product");
    Console.WriteLine("3. Remove Product");
    Console.WriteLine("4. View Inventory");
    Console.WriteLine("5. Exit");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddAction();
            break;
        case "2":
            UpdateAction();
            break;
        case "3":
            RemoveAction();
            break;
        case "4":
            inventory.ListInventory();
            break;
        case "5":
            Console.WriteLine("Exiting inventory management system. Thank you!");
            running = false;
            break;
        default:
            Console.WriteLine("Invalid selection. Please enter the number of the action.");
            break;
    }
} while (running);


#region Program Actions

void AddAction()
{
    string? name = null;
    while (name == null)
    {
        Console.WriteLine("What is the name of the product?");
        name = Console.ReadLine();
    }

    double? price = null;
    while (price == null)
    {
        Console.WriteLine("What is the price?");
        if (double.TryParse(Console.ReadLine(), out var result))
        {
            price = Math.Round(result, 2);
        }
    }

    int? quantity = null;
    while (quantity == null)
    {
        Console.WriteLine("How many are there?");
        if (int.TryParse(Console.ReadLine(), out var result))
        {
            quantity = result;
        }
    }

    inventory.AddProduct(name, (double)price, (int)quantity);
}

void UpdateAction()
{
    if (inventory.Products.Count == 0)
    {
        Console.WriteLine("Inventory is empty. You must add an item to use this action.");
        return;
    }

    string? name = null;
    while (name == null)
    {
        Console.WriteLine("What is the name of the product?");
        name = Console.ReadLine();
    }

    Console.WriteLine("What's the new price? (Leave blank to keep current value)");
    double? price = null;

    if (double.TryParse(Console.ReadLine(), out var p))
    {
        price = Math.Round(p, 2);
    }

    Console.WriteLine("What's the new quantity? (Leave blank to keep current value)");
    int? quantity = null;

    if (int.TryParse(Console.ReadLine(), out var q))
    {
        quantity = q;
    }

    inventory.UpdateProduct(name, price, quantity);
}

void RemoveAction()
{
    if (inventory.Products.Count == 0)
    {
        Console.WriteLine("Inventory is empty. You must add an item to use this action.");
        return;
    }

    string? name = null;
    while (name == null)
    {
        Console.WriteLine("What is the name of the product?");
        name = Console.ReadLine();
    }

    inventory.RemoveProduct(name);
}

#endregion