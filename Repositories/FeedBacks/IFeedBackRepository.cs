namespace Repositories.FeedBacks;
using BusinessObject.Entities;
public interface IFeedBackRepository
{
    IEnumerable<FeedBack> GetAllFeedBackByProductId(string productId);
}