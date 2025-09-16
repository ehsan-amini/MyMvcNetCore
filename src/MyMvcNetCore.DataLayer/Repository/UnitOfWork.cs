
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;

namespace MyMvcNetCore.DataLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyMvcNetCoreDbContext _dbContext;
        public ICategoryRepository CategoryRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ICartRepository CartRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public IProductImageRepository ProductImageRepository { get; private set; }

        public UnitOfWork(MyMvcNetCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            CategoryRepository = new CategoryRepository(_dbContext);
            CompanyRepository = new CompanyRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
            CartRepository = new CartRepository(_dbContext);
            ApplicationUserRepository = new ApplicationUserRepository(_dbContext);
            OrderRepository = new OrderRepository(_dbContext);
            OrderDetailRepository = new OrderDetailRepository(_dbContext);
            ProductImageRepository = new ProductImageRepository(_dbContext);
        }
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();


        }

    }
}