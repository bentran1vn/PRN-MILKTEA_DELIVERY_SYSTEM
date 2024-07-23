using System.Text;
using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Products;
using Repositories.UploadFileService;

namespace RazorPages.Pages;

public class ProductDetailPage(IProductRepository productRepository, IImageUploadService imageUploadService) : PageModel
{
    
    [BindProperty] public ProductModel ProductModel { set; get; }
    
    public IActionResult OnGet(string? id)
    {
        if (id != null)
        {
            var result = productRepository.GetProductById(id);
            ProductModel = new ProductModel()
            {
                ProductName = result?.ProductName,
                Price = result.Price,
                Quantity = result.Quantity,
                ProductDescription = result.ProductDescription,
                ProductType = result.ProductType,
            };
            IdUpdate = result.ProductID;
            Imgs = result.Imgs;
            return Page();
        }

        return RedirectToPage("./ProductManagePage");
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Console.WriteLine(IdUpdate);
        if (ProductModel.FileUpload != null && ProductModel.FileUpload.Length > 0)
        {
            var guidId = Guid.NewGuid();

            var imageURL = await imageUploadService.UploadFile(ProductModel.FileUpload, guidId);
            var now = DateTime.Now;
            var product = new Product()
            {
                ProductID = IdUpdate,
                Price = ProductModel.Price,
                Quantity = ProductModel.Quantity,
                ProductDescription = ProductModel.ProductDescription,
                ProductName = ProductModel.ProductName,
                ProductType = ProductModel.ProductType,
                Imgs = imageURL
            };
            productRepository.Update(product);
            return RedirectToPage("./ProductManagePage");
        }
        else
        {
            var product = new Product()
            {
                ProductID = IdUpdate,
                Price = ProductModel.Price,
                Quantity = ProductModel.Quantity,
                ProductDescription = ProductModel.ProductDescription,
                ProductName = ProductModel.ProductName,
                ProductType = ProductModel.ProductType,
                Imgs = Imgs
            };
            productRepository.Update(product);
            return RedirectToPage("./ProductManagePage");
        }
    }
    
    public string IdUpdate
    {
        get
        {
            if (HttpContext.Session.TryGetValue("IdUpdate", out byte[] value))
            {
                return Encoding.UTF8.GetString(value);
            }
            return string.Empty;
        }
        set
        {
            HttpContext.Session.Set("IdUpdate", Encoding.UTF8.GetBytes(value));
        }
    }
    
    public string Imgs
    {
        get
        {
            if (HttpContext.Session.TryGetValue("Imgs", out byte[] value))
            {
                return Encoding.UTF8.GetString(value);
            }
            return string.Empty;
        }
        set
        {
            HttpContext.Session.Set("Imgs", Encoding.UTF8.GetBytes(value));
        }
    }
}