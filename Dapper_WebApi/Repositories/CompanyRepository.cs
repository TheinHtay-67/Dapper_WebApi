using Dapper;
using Dapper_WebApi.Context;
using Dapper_WebApi.Interface;
using Dapper_WebApi.Model;

namespace Dapper_WebApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var query = "SELECT * FROM Companies";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }
    }
}
