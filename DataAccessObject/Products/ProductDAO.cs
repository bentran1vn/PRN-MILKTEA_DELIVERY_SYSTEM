using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessObject.Products;

public class ProductDAO
{
    private MilkTeaDeliveryDBContext _context = new();
    public IEnumerable<Product> GetAll()
    {
        return _context.Products.AsNoTracking();
    }

    public IEnumerable<Product> Search(string name)
        => _context.Products.Where(x => x.ProductName.Contains(name)).AsNoTracking();

    public IEnumerable<Product> Filter(IList<Product> products, List<string> category, string priceOpt)
    {
        IEnumerable<Product> result = products;
        if (category.Count == 1 && int.TryParse(category.First(), out int type))
        {
            result = result.Where(x => x.ProductType == type);
        }

        if (int.TryParse(priceOpt, out int priceOption))
        {
            switch (priceOption)
            {
                case 1:
                    result = result.OrderBy(x => x.Price);
                    break;
                case 2:
                    result = result.OrderByDescending(x => x.Price);
                    break;
            }
        }
        return result;
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

    public object GetAllDesc()
    {
        throw new NotImplementedException();
    }
}