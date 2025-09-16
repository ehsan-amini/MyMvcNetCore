

using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly MyMvcNetCoreDbContext _dbContext;

        public CompanyRepository(MyMvcNetCoreDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Update(Company company)
        {
            _dbContext.Companies.Update(company);
        }
    }
}
