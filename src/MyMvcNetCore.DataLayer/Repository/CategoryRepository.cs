
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;


namespace MyMvcNetCore.DataLayer.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        MyMvcNetCoreDbContext _dbContext;

        public CategoryRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }




    }
}
