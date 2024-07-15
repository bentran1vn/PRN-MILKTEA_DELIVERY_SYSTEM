using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.FeedBacks;
using Repositories.OrderDetails;

namespace RazorPages.Pages
{
    public class FeedBackModel : PageModel
    {

        private readonly IFeedBackRepository _feedBackRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public FeedBackModel(IFeedBackRepository feedBackRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _feedBackRepository = feedBackRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }
        [TempData]
        public string Message { get; set; }
        [TempData]
        public int IsSuccess { get; set; } = 0;
        [TempData]
        public int Cout { get; set; } = 0;
        public string OrderID { get; set; }
        [BindProperty]
        public FeedBack FeedBack { get; set; } = default!;
        public void OnGet(string id)
        {
            OrderID = id;
        }
        public IActionResult OnPost(string id)
        {
            OrderID = id;
            var x = _orderDetailsRepository.GetOrderDetailIDsFromOrderID(id);
            try
            {
                foreach (var item in x)
                {
                    var Feedback = new FeedBack
                    {
                        userID = User.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value,
                        content = FeedBack.content,
                        point = 0,
                        OrderDetailId = item,
                        status = true

                    };

                    _feedBackRepository.AddFeedbackToAllOrderDetail(Feedback);
                }
            }
            catch
            {
                Message = "You have already feedback this order";
                IsSuccess = 1;
                return Page();
            }
            Message = "Feedback success";

            Cout++;
            IsSuccess = 2;
            Task.Delay(2000);
            return RedirectToPage("OrderFeebback");

        }
    }
}
