using Dapper_WebApi.DTO;
using Dapper_WebApi.Model;

namespace Dapper_WebApi.Interface
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> CreateCompany(CompanyDto company);
    }
}
