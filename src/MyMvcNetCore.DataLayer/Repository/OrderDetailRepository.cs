
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly MyMvcNetCoreDbContext _dbContext;

        public OrderDetailRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
        }
    }
}
