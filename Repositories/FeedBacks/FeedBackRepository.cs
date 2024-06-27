using BusinessObject.Entities;
using DataAccessObject.Feedback;

namespace Repositories.FeedBacks;

public class FeedBackRepository: IFeedBackRepository
{
    private readonly FeedbackDAO _dao = new();

    public IEnumerable<FeedBack> GetAllFeedBackByProductId(string productId)
    {
        return _dao.GetAllFeedBackByProductId(productId);
    }
}