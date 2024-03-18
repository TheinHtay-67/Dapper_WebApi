using Dapper_WebApi.Model;

namespace Dapper_WebApi.Interface
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
    }
}
