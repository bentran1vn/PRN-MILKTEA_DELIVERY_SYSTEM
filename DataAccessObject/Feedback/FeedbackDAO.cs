using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject.Feedback;

public class FeedbackDAO
{
    private MilkTeaDeliveryDBContext _context = new();

    public IEnumerable<FeedBack> GetAllFeedBackByProductId(string productId)
    {
        var orderIds = _context.OrderDetails.AsNoTracking().Where(x => x.productID.Equals(productId)).Select(x => x.Id);
        return _context.FeedBacks.Include(x => x.User).AsNoTracking().Where(x => orderIds.Contains(x.OrderDetailId));
    }

    public IEnumerable<FeedBack> GetAllFeedBackByUserId(string userId)
    {
        return _context.FeedBacks.Include(x => x.User).AsNoTracking().Where(x => x.userID.Equals(userId));
    }

    public void AddFeedbackToAllOrderDetail(FeedBack feedBack)
    {
        _context.FeedBacks.Add(feedBack);
        _context.SaveChanges();
    }
}