using MyMvcNetCore.Entities;

namespace MyMvcNetCore.DataLayer.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}
