using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        public void Update(Cart cart);
    }
}
