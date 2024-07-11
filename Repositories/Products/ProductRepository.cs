using BusinessObject.Entities;
using DataAccessObject.Products;

namespace Repositories.Products;


public class ProductRepository : IProductRepository
{
    private readonly ProductDAO _dao = new();

    public IEnumerable<Product> GetAll(int pageNum, int pageSize)
    {
        var result = _dao.GetAll();
        return result.Skip((pageNum - 1) * pageSize).Take(pageSize);
    }

    public IEnumerable<Product> Search(string name, int pageNum, int pageSize)
    {
        IEnumerable<Product> result;
        if (name == null)
            result = _dao.GetAll();
        else
            result = _dao.Search(name);
        return result.Skip((pageNum - 1) * pageSize).Take(pageSize);
    }
    public IEnumerable<Product> Search(string name)
    {
        IEnumerable<Product> result;
        if (name == null)
            result = _dao.GetAll();
        else
            result = _dao.Search(name);
        return result;
    }
    public IEnumerable<Product> Pagination(IList<Product> list, int pageNum, int pageSize)
        =>  list.Skip((pageNum - 1) * pageSize).Take(pageSize);

    public IEnumerable<Product> Filter(IList<Product> products, List<string> type, string priceOption)
    {
        var result = _dao.Filter(products, type, priceOption);
        return result;
    }

    public IEnumerable<Product> GetAllDes(int pageNum, int pageSize)
    {
        var result = _dao.GetAll().OrderByDescending(x => x.CreateAt);
        return result.Skip((pageNum - 1) * pageSize).Take(pageSize);
    }

    public IEnumerable<Product> GetAll()
    {
        return _dao.GetAll();
    }

    public void DeleteProduct(string productId)
    {
        _dao.Delete(productId);
    }

    public async Task AddProduct(Product product)
    {
        await _dao.Add(product);
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

    public int GetCountBySearch(string keyword) => _dao.Search(keyword).Count();
    public int GetCountByFilter(IList<Product> products, List<string> type, string priceOption) => _dao.Filter(products, type, priceOption).Count();
    public Task UpdateProductQuantity(List<ProductCartModel> products)
    {
        return _dao.MinusQuanity(products);
    }
}