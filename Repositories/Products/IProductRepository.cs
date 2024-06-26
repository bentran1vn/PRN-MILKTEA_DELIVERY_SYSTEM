namespace Repositories.Products;
using BusinessObject.Entities;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    void DeleteCategory(string productId);
    void AddCategory(Product product);
    void UpdateCategory(Product product);
    Product? GetProductById(string productId);
    IEnumerable<Product> GetAll4(string productId);
    IEnumerable<Product> GetAll6();
    IEnumerable<Product> GetAllFormSession(List<string> productIds);
}