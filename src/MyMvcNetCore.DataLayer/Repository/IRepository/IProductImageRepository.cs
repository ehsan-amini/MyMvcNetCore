

using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        void Update(ProductImage productImage);
    }
}
