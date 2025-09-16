using System.Linq.Expressions;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(int id);

        T FindById(int id);

        Task<T> FindByIdAsync(int id);

        List<T> GetAll();

        Task<List<T>> GetAllAsync();
    }
}
