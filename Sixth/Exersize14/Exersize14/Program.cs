using System;
using System.Collections.Generic;

// Product class
public class Product : IEquatable<Product>
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    public bool Equals(Product other)
    {
        if (other == null) return false;
        return this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Product);
    }
}

// Inventory class
public class Inventory
{
    private Dictionary<Product, int> _products = new Dictionary<Product, int>();
    private decimal _totalValue = 0m;

    public IReadOnlyDictionary<Product, int> Products => _products;
    public decimal TotalValue => _totalValue;

    // Event handlers create
    public event EventHandler<Product> ProductAdded;
    public event EventHandler<Product> ProductRemoved;
    public event EventHandler<Product> ProductQuantityUpdated;
    public event EventHandler<Product> ProductPriceUpdated;

    // Add all the product to inventory
    public void AddProduct(Product product, int quantity)
    {
        if (_products.TryGetValue(product, out int existingQuantity))
        {
            _products[product] = existingQuantity + quantity;
        }
        else
        {
            _products.Add(product, quantity);
            ProductAdded?.Invoke(this, product);
        }

        _totalValue += product.Price * quantity;
        ProductQuantityUpdated?.Invoke(this, product);
        ProductPriceUpdated?.Invoke(this, product);
    }

    // Remove product from inventory 
    public void RemoveProduct(Product product)
    {
        if (_products.TryGetValue(product, out int quantity))
        {
            _products.Remove(product);
            _totalValue -= product.Price * quantity;
            ProductRemoved?.Invoke(this, product);
            ProductQuantityUpdated?.Invoke(this, product);
            ProductPriceUpdated?.Invoke(this, product);
        }
    }

    // Update product quantity in inventory
    public void UpdateProductQuantity(Product product, int newQuantity)
    {
        if (_products.TryGetValue(product, out int existingQuantity))
        {
            _products[product] = newQuantity;
            _totalValue += product.Price * (newQuantity - existingQuantity);
            ProductQuantityUpdated?.Invoke(this, product);
        }
    }

    // Update product price in inventory
    public void UpdateProductPrice(Product product, decimal newPrice)
    {
        if (_products.TryGetValue(product, out int quantity))
        {
            _totalValue -= product.Price * quantity;
            product.Price = newPrice;
            _totalValue += newPrice * quantity;
            ProductPriceUpdated?.Invoke(this, product);
        }
    }

    // defective remove product from inventory
    public void RemoveDefectiveProduct(Product product)
    {
        RemoveProduct(product);
    }

    static void Main(string[] args)
    {

        var inventory = new Inventory();

        // Event handlers
        inventory.ProductAdded += (sender, product) => Console.WriteLine($"Product added: {product.Id}");
        inventory.ProductQuantityUpdated += (sender, product) => Console.WriteLine($"Product quantity updated: {product.Id}");
        inventory.ProductPriceUpdated += (sender, product) => Console.WriteLine($"Product price updated: {product.Id}");
        inventory.ProductRemoved += (sender, product) => Console.WriteLine($"Product removed: {product.Id}");

        // Add products using user input
        while (true)
        {
            Console.WriteLine("Enter product ID (or 'exit' to stop adding products):");
            string idInput = Console.ReadLine();
            if (idInput.ToLower() == "exit")
                break;

            if (!int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Invalid input, please enter a number or 'exit'.");
                continue;
            }

            Console.WriteLine("Enter product price:");
            string priceInput = Console.ReadLine();
            if (!decimal.TryParse(priceInput, out decimal price))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            var product = new Product { Id = id, Price = price };
            Console.WriteLine($"Adding product: {product.Id} (price: {product.Price})");
            inventory.AddProduct(product, 1);
        }

        // Show the inventory's total value
        Console.WriteLine($"Total value of inventory: {inventory.TotalValue}");
    }
}