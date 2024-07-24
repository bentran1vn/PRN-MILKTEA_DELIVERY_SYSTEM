using BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.FeedBacks;

namespace RazorPages.Pages
{
    public class ViewAllFeebbacksModel : PageModel
    {
        private readonly IFeedBackRepository feedBackRepository;

        public ViewAllFeebbacksModel(IFeedBackRepository feedBackRepository)
        {
            this.feedBackRepository = feedBackRepository;
        }
        [BindProperty]
        public IEnumerable<FeedBack> FeedBacks { get; set; }
        public void OnGet()
        {
            var userID = User.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            FeedBacks = feedBackRepository.GetAllFeedBackByUserId(userID);
        }
    }
}
