using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
