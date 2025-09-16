
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using System.Linq.Expressions;

namespace MyMvcNetCore.DataLayer.Repository
{

    
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        protected readonly MyMvcNetCoreDbContext _dbContext;
        internal DbSet<T> _dbSet;
        public Repository(MyMvcNetCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
            => _dbSet.Add(entity);

        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public void Remove(T entity)
            => _dbSet.Remove(entity);

        public void Remove(int id)
        {
            var trackedEntity = _dbSet.Local.FirstOrDefault(e =>
            {
                var idProp = typeof(T).GetProperty("Id");
                return (int)idProp.GetValue(e)! == id;
            });

            if (trackedEntity != null)
            {
                _dbSet.Remove(trackedEntity);
                return;
            }

            var tEntity = new T();
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
                throw new Exception("The entity doesn't have Id property!");

            idProperty.SetValue(tEntity, id);

            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public T FindById(int id)
            => _dbSet.Find(id);

        public async Task<T> FindByIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public List<T> GetAll()
            => _dbSet.ToList();

        public async Task<List<T>> GetAllAsync()
            => await _dbSet.ToListAsync();
    }
}

