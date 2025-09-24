

using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;


namespace MyMvcNetCore.DataLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        MyMvcNetCoreDbContext _dbContext;

        public ProductRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
        }
    }
}
