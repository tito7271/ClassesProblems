using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string productName = "Banana";
        double productPrice = 10.99;
        int productQuantity = 6;

        // Act
        this._inventory.AddProduct(productName, productPrice, productQuantity);
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo($"Product Inventory:{Environment.NewLine}" +
            $"Banana - Price: $10.99 - Quantity: 6"));
        
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange & Act
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo("Product Inventory:"));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        this._inventory.AddProduct("banana", 13.29, 1);
        this._inventory.AddProduct("cherry", 10, 2);


        // Act
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo($"Product Inventory:{Environment.NewLine}" +
            $"banana - Price: $13.29 - Quantity: 1{Environment.NewLine}" +
            $"cherry - Price: $10.00 - Quantity: 2"));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange & Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.Zero);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        this._inventory.AddProduct("banana", 13.29, 1);
        this._inventory.AddProduct("cherry", 10, 2);

        // Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(33.29));
    }
}
