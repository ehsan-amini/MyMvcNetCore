
using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order orderHeader);
        void UpdateStatus(int id, int orderStatus, int? paymentStatus =  null);
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}
