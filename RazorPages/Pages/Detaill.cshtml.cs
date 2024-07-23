using System.Collections;
using BusinessObject.Entities;
using DataAccessObject.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Utils;
using Repositories.FeedBacks;
using Repositories.Products;

namespace RazorPages.Pages;

public class Detaill : PageModel
{
    private readonly IProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFeedBackRepository _feedBackRepository;

    public Detaill(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor,IFeedBackRepository feedBackRepository)
    {
        _productRepository = productRepository;
        _httpContextAccessor = httpContextAccessor;
        _feedBackRepository = feedBackRepository;
    }
    
    [BindProperty] 
    public Product ProductModel { set; get; }
    
    [BindProperty] 
    public ProductCartModel ProductCartInput { set; get; }
    
    [BindProperty] 
    public IList<Product> ProductList4 { set; get; }
    
    [BindProperty] 
    public IList<FeedBack> FeedbackItems { set; get; }
    

    public IActionResult OnGet(string? id)
    {
        if (id == null) RedirectToPage("./Index");
        var result = _productRepository.GetProductById(id!);
        var result4 = _productRepository.GetAll4(id!).ToList();
        var resultFeed = _feedBackRepository.GetAllFeedBackByProductId(id!).ToList();
        if(result == null) RedirectToPage("./Index");
        ProductModel = result!;
        ProductList4 = result4;
        FeedbackItems = resultFeed;
        ProductCartInput = new ProductCartModel()
        {
            ProductId = result!.ProductID
        };
        return Page();
    }
    
    public IActionResult OnPost()
    {
        
        ModelState.Clear();
        
        TryValidateModel(ProductCartInput, nameof(ProductCartInput));
        
        if (!ModelState.IsValid)
        {
            var result = _productRepository.GetProductById(ProductCartInput.ProductId);
            var result4 = _productRepository.GetAll4(ProductCartInput.ProductId).ToList();
            var resultFeed = _feedBackRepository.GetAllFeedBackByProductId(ProductCartInput.ProductId).ToList();
            ProductModel = result!;
            // ProductList4 = result4;
            FeedbackItems = resultFeed;
            return Page();
        }
        Console.WriteLine("phahah");
        _httpContextAccessor?.HttpContext?.Session.AddProductToCart(ProductCartInput.ProductId, ProductCartInput.Quantity);
        return RedirectToPage("./Detaill", new { id = ProductCartInput.ProductId });
    }
}