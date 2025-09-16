
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities.Identity;


namespace MyMvcNetCore.DataLayer.Repository  
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly MyMvcNetCoreDbContext _dbContext;

        public ApplicationUserRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
