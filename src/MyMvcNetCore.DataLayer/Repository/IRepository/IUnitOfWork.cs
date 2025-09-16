using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.DataLayer.Context;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IProductRepository ProductRepository { get; }
        ICartRepository CartRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IProductImageRepository ProductImageRepository { get; }


        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Save();
        Task SaveAsync();



    }
}
