using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        MyMvcNetCoreDbContext _dbContext;

        public ProductImageRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(ProductImage productImage)
        {
            _dbContext.ProductImages.Update(productImage);
        }
    }
}
