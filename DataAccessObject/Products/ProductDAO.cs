using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Extensions;

namespace DataAccessObject.Products;

public class ProductDAO
{
    private MilkTeaDeliveryDBContext _context = new();
    public IEnumerable<Product> GetAll()
    {
        return _context.Products.AsNoTracking();
    }

    public void Delete(string productId)
    {
        var product = _context.Products.FirstOrDefault(x => x.ProductID == productId);
        if (product == null) throw new Exception("Can not find Entity");
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public Product? FindProductById(string productId)
    {
        return _context.Products.AsNoTracking().FirstOrDefault(x => x.ProductID.Equals(productId));
    }

    public async Task MinusQuanity(List<ProductCartModel> products)
    {
        var productIdsToUpdate = products.Select(p => p.ProductId).ToList();

        var productsToUpdate = await _context.Products
            .AsNoTracking()
            .Where(p => productIdsToUpdate.Contains(p.ProductID))
            .ToListAsync();
        foreach (var item in productsToUpdate)
        {
            item.Quantity -= products.FirstOrDefault(x => x.ProductId.Equals(item.ProductID))!.Quantity;
        }
        
        _context.Products.UpdateRange(productsToUpdate);
        await _context.SaveChangesAsync();
    }
}

public class ProductCartModel
{
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; } = 1;
}