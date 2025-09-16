

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
            var productFromDb = _dbContext.Products.FirstOrDefault(u => u.Id == product.Id);
            if (productFromDb != null)
            {
                //productFromDb.Title = product.Title;
                //productFromDb.ISBN = product.ISBN;
                //productFromDb.Price = product.Price;
                //productFromDb.Price50 = product.Price50;
                //productFromDb.ListPrice = product.ListPrice;
                //productFromDb.Price100 = product.Price100;
                //productFromDb.Description = product.Description;
                //productFromDb.CategoryId = product.CategoryId;
                //productFromDb.Author = product.Author;
                //productFromDb.ProductImages = product.ProductImages;
            }
        }
    }
}
