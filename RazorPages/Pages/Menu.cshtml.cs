using BusinessObject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Repositories.Products;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RazorPages.Pages;

public class Menu(IProductRepository _productRepository) : PageModel
{
    [BindProperty] public IList<Product> ProductList { set; get; } = _productRepository.GetAll(1, 9).ToList();

    [BindProperty] public int TotalProPage { set; get; }

    [BindProperty] public string Keyword { set; get; }


    public void OnGet([FromQuery] string keyword, List<string> category, string priceFilter, string? pageNum = "1", string pageSize = "9")
    {
        if (!Int32.TryParse(pageNum, out int pageNumInt)) return;
        Keyword = keyword;

        List<Product> list = new List<Product>();
        var listString = HttpContext.Session.GetString("productList");

        if (!string.IsNullOrEmpty(listString))
            list = JsonConvert.DeserializeObject<List<Product>>(listString);

        Keyword = !string.IsNullOrEmpty(keyword) ? keyword : HttpContext.Session.GetString("keyword");

        if (HttpContext.Session.GetInt32("PageLoadCount") == null)
        {
            HttpContext.Session.SetInt32("PageLoadCount", 1);
        }
        else if(HttpContext.Session.GetInt32("PageLoadCount") > 2)
        {
            int loadCount = HttpContext.Session.GetInt32("PageLoadCount").Value;
            HttpContext.Session.SetInt32("PageLoadCount", loadCount + 1);
            Keyword = null;
            HttpContext.Session.Clear();
        }
        else
        {
            int loadCount = HttpContext.Session.GetInt32("PageLoadCount").Value;
            HttpContext.Session.SetInt32("PageLoadCount", loadCount + 1);
        }


        if (string.IsNullOrEmpty(Keyword) && category.Count == 0 && string.IsNullOrEmpty(priceFilter))
        {
            list = _productRepository.GetAll().ToList();
            listString = JsonConvert.SerializeObject(list);
            HttpContext.Session.SetString("productList", listString);

            ProductList = _productRepository.Pagination(list, pageNumInt, 9).ToList();
            int count = _productRepository.GetCount();
            int result = (int)Math.Ceiling(count / 9.0);
            TotalProPage = result;
        }

        else if (!string.IsNullOrEmpty(Keyword))
        {
            list = _productRepository.Search(Keyword).ToList();
            HttpContext.Session.SetString("productList", listString);
            HttpContext.Session.SetString("keyword", Keyword);


            ProductList = _productRepository.Pagination(list, pageNumInt, 9).ToList();
            int count = list.Count;
            int result = (int)Math.Ceiling(count / 9.0);
            TotalProPage = result;
        }
        else
        {

            if (category.Count != 0)
                HttpContext.Session.SetString("categoryList", JsonConvert.SerializeObject(category));
            if (!string.IsNullOrEmpty(priceFilter))
                HttpContext.Session.SetString("priceFilter", priceFilter);

            var listWithOutPagination = _productRepository.Filter(list, category, priceFilter).ToList();
            ProductList = _productRepository.Pagination(listWithOutPagination, pageNumInt, 9).ToList();

            int count = listWithOutPagination.Count;
            int result = (int)Math.Ceiling(count / 9.0);
            TotalProPage = result;
        }
    }
}