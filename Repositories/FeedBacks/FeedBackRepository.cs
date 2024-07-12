using BusinessObject.Entities;
using DataAccessObject.Feedback;

namespace Repositories.FeedBacks;

public class FeedBackRepository : IFeedBackRepository
{
    private readonly FeedbackDAO _dao = new();

    public void AddFeedbackToAllOrderDetail(FeedBack feedBack)
    {
        _dao.AddFeedbackToAllOrderDetail(feedBack);
    }

    public IEnumerable<FeedBack> GetAllFeedBackByProductId(string productId)
    {
        return _dao.GetAllFeedBackByProductId(productId);
    }

    public IEnumerable<FeedBack> GetAllFeedBackByUserId(string userId)
    {
        return _dao.GetAllFeedBackByUserId(userId);
    }

  
}