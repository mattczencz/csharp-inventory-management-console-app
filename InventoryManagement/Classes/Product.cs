namespace InventoryManagement.Classes;

public class Product(string name, double price, int quantity)
{
    public string Name { get; private set; } = name;
    public double Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
}