using ArrestedAPI.Models;

namespace ArrestedAPI.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product?> UpdateAsync(int id, Product product);
    Task<bool> DeleteAsync(int id);
}

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public ProductService()
    {
        // Seed with some initial data
        _products.AddRange(new[]
        {
            new Product { Id = _nextId++, Name = "Laptop", Description = "High-performance laptop", Price = 999.99m },
            new Product { Id = _nextId++, Name = "Mouse", Description = "Wireless optical mouse", Price = 29.99m },
            new Product { Id = _nextId++, Name = "Keyboard", Description = "Mechanical gaming keyboard", Price = 149.99m }
        });
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult(_products.Where(p => p.IsActive).AsEnumerable());
    }

    public Task<Product?> GetByIdAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id && p.IsActive);
        return Task.FromResult(product);
    }

    public Task<Product> CreateAsync(Product product)
    {
        product.Id = _nextId++;
        product.CreatedAt = DateTime.UtcNow;
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task<Product?> UpdateAsync(int id, Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null) return Task.FromResult<Product?>(null);

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.IsActive = product.IsActive;

        return Task.FromResult<Product?>(existingProduct);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null) return Task.FromResult(false);

        product.IsActive = false; // Soft delete
        return Task.FromResult(true);
    }
}