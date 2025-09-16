using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;


namespace MyMvcNetCore.DataLayer.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly MyMvcNetCoreDbContext _dbContext;

        public CartRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Update(Cart Cart)
        {
            _dbContext.Carts.Update(Cart);
        }
    }
}
