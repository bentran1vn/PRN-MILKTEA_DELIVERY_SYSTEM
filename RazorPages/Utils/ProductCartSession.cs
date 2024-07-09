using DataAccessObject.Products;

namespace RazorPages.Utils;
using JsonSerializer = System.Text.Json.JsonSerializer;

public static class ProductCartSession
{
    public static void AddProductToCart(this ISession session, string productId, int quantity)
    {
        // Retrieve the cart list from the session
        var listJson = session.GetString("Cart");
        List<ProductCartModel>? list;

        if (listJson != null)
        {
            list = JsonSerializer.Deserialize<List<ProductCartModel>>(listJson);
        }
        else
        {
            list = new List<ProductCartModel>();
        }

        if (list != null)
        {
            var existingProduct = list.FirstOrDefault(x => x.ProductId.Equals(productId, StringComparison.OrdinalIgnoreCase));
        
            if (existingProduct != null)
            {
                existingProduct.Quantity += quantity;
            }
            else
            {
                list.Add(new ProductCartModel()
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            session.SetString("Cart", JsonSerializer.Serialize(list));
        }
    }
    
    public static void RemoveProductFromCart(this ISession session, string productId)
    {
        var listJson = session.GetString("Cart");
    
        if (listJson != null)
        {
            var list = JsonSerializer.Deserialize<List<ProductCartModel>>(listJson);

            if (list != null)
            {
                var productToRemove = list.FirstOrDefault(x => x.ProductId.Equals(productId, StringComparison.OrdinalIgnoreCase));
            
                if (productToRemove != null)
                {
                    list.Remove(productToRemove);
                    
                    session.SetString("Cart", JsonSerializer.Serialize(list));
                }
            }
        }
    }
}
