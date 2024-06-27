using BusinessObject.Entities;
using DataAccessObject.Products;

namespace Repositories.Products;


public class ProductRepository: IProductRepository
{
    private readonly ProductDAO _dao = new();

    public IEnumerable<Product> GetAll(int pageNum, int pageSize)
    {
        var result = _dao.GetAll();
        return result.Skip((pageNum-1) * pageSize).Take(pageSize);
    }

    public IEnumerable<Product> GetAll()
    {
        return _dao.GetAll();
    }

    public void DeleteCategory(string productId)
    {
        _dao.Delete(productId);
    }

    public void AddCategory(Product product)
    {
        _dao.Add(product);
    }

    public void UpdateCategory(Product product)
    {
        _dao.Update(product);
    }

    public Product? GetProductById(string productId)
    {
        return _dao.FindProductById(productId);
    }

    public IEnumerable<Product> GetAll4(string productId)
    {
        Random random = new Random();
        return _dao.GetAll()
            .Where(x => !x.ProductID.Equals(productId))
            .OrderBy(_ => random.Next())
            .Take(4);
    }

    public IEnumerable<Product> GetAll6()
    {
        Random random = new Random();
        return _dao.GetAll()
            .OrderBy(_ => random.Next())
            .Take(6);
    }

    public IEnumerable<Product> GetAllFormSession(List<string> productIds)
    {
        return _dao.GetAll().Where(x => productIds.Contains(x.ProductID));
    }

    public int GetCount()
    {
        return _dao.GetAll().Count();
    }
}