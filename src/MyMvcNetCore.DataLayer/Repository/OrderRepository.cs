
using MyMvcNetCore.Commen.Enums;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;


namespace MyMvcNetCore.DataLayer.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly MyMvcNetCoreDbContext _dbContext;

        public OrderRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Update(Order order)
        {
            _dbContext.Orders.Update(order);
        }

        public void UpdateStatus(int id, int orderStatus, int? paymentStatus = null)
        {
            var orderFromDb = _dbContext.Orders.FirstOrDefault(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = (OrderStatus)orderStatus;
                if (paymentStatus>0)
                    orderFromDb.PaymentStatus = (PaymentStatus)paymentStatus;
            }
        }

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = _dbContext.Orders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
                orderFromDb.SessionId = sessionId;

            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}
