using DataAccessObject.Products;

namespace Repositories.Products;
using BusinessObject.Entities;

public interface IProductRepository
{
    IEnumerable<Product> GetAll(int pageNum, int pageSize);
    
    IEnumerable<Product> GetAllDes(int pageNum, int pageSize);
    IEnumerable<Product> GetAll();
    void DeleteProduct(string productId);
    Task AddProduct(Product product);
    void UpdateCategory(Product product);
    Product? GetProductById(string productId);
    IEnumerable<Product> GetAll4(string productId);
    IEnumerable<Product> GetAll6();
    IEnumerable<Product> GetAllFormSession(List<string> productIds);
    int GetCount();
    Task UpdateProductQuantity(List<ProductCartModel> products);
}