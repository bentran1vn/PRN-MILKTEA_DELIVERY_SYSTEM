namespace Repositories.Products;
using BusinessObject.Entities;

public interface IProductRepository
{
    IEnumerable<Product> GetAll(int pageNum, int pageSize);
    IEnumerable<Product> Search(string name, int pageNum, int pageSize);
    IEnumerable<Product> Search(string name);
    IEnumerable<Product> Pagination(IList<Product> list, int pageNum, int pageSize);
    IEnumerable<Product> Filter(IList<Product> products, List<string> type, string priceOption);
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
    int GetCountBySearch(string keyword);
    int GetCountByFilter(IList<Product> products, List<string> type, string priceOption);
}