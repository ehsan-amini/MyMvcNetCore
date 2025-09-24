
using MyMvcNetCore.Entities;


namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }

}
