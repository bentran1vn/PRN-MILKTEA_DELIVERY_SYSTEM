namespace Repositories.FeedBacks;
using BusinessObject.Entities;
public interface IFeedBackRepository
{
    IEnumerable<FeedBack> GetAllFeedBackByProductId(string productId);

    IEnumerable<FeedBack> GetAllFeedBackByUserId(string userId);
    void AddFeedbackToAllOrderDetail(FeedBack feedBack);


}