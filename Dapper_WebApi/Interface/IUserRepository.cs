using Dapper_WebApi.DTO;
using Dapper_WebApi.Model;

namespace Dapper_WebApi.Interface
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(UserDto user);
    }
}
