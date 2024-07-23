using System.ComponentModel.DataAnnotations;
using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Repositories.Products;
using Repositories.SignalR;
using Repositories.UploadFileService;

namespace RazorPages.Pages;

public class ProductAddNewPage(IImageUploadService imageUploadService, IProductRepository productRepository,IHubContext<SignalrServer> hubContext) : PageModel
{
    [BindProperty]
    public ProductModel ProductModel { get; set; }

    public string Message { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        if (ProductModel.FileUpload != null && ProductModel.FileUpload.Length > 0)
        {
            var guidId = Guid.NewGuid();
            
            // Local Image
            // Generate a unique filename
            // var fileName = guidId.ToString() + Path.GetExtension(FileUpload.FileName);
            //     
            // // Specify the path to save the uploaded file
            // var filePath = Path.Combine("wwwroot/uploads", fileName);
            //
            // // Ensure the directory exists
            // Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            //
            // // Save the file
            // using (var stream = new FileStream(filePath, FileMode.Create))
            // {
            //     await FileUpload.CopyToAsync(stream);
            // }

            var imageURL = await imageUploadService.UploadFile(ProductModel.FileUpload, guidId);
            var now = DateTime.Now;
            var product = new Product()
            {
                ProductID = guidId.ToString(),
                Price = ProductModel.Price,
                Quantity = ProductModel.Quantity,
                ProductDescription = ProductModel.ProductDescription,
                ProductName = ProductModel.ProductName,
                ProductType = ProductModel.ProductType,
                CreateAt = now,
                Imgs = imageURL
            };
            
            await productRepository.AddProduct(product);

            Message = $"{imageURL}";
            
            await hubContext.Clients.All.SendAsync("NewProduct");
            
            return RedirectToPage("./ProductManagePage");
        }
        else
        {
            Message = "Product Image Empty, Please select a file to upload.";
            return Page();
        }
    }
    public void OnGet()
    {
        
    }
}

public class ProductModel
{
    // public string ProductID { get; set; }
    [Required]
    public required string ProductName { get; set; }
    [Required]
    public required string ProductDescription { get; set; }
    [Required]
    public required int ProductType { get; set; } // 1 for hot, 0 for cool
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public required double Price { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public required int Quantity { get; set; }
    
    public IFormFile? FileUpload { get; set; }
}