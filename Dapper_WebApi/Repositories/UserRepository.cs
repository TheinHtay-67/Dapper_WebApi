using Dapper;
using Dapper_WebApi.Context;
using Dapper_WebApi.DTO;
using Dapper_WebApi.Interface;
using Dapper_WebApi.Model;
using System.Data;

namespace Dapper_WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(UserDto userDto)
        {
            var query = "INSERT INTO Users (UserName, Email, Password, RoleId) VALUES (@UserName, @Email, @Password, @RoleId);" +
                "SELECT u.Id, u.UserName, u.Email, r.Name as RoleName FROM Users u JOIN Roles r ON u.RoleId = r.Id WHERE u.Id = SCOPE_IDENTITY();";

            var parameters = new DynamicParameters();
            parameters.Add("UserName", userDto.UserName, DbType.String);
            parameters.Add("Email", userDto.Email, DbType.String);
            parameters.Add("Password", userDto.Password, DbType.String);
            parameters.Add("RoleId", userDto.RoleId, DbType.Int32);

            using(var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleAsync<User>(query, parameters);
                var createdUser = new User
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleName = user.RoleName
                };
                return createdUser;
            }
        }
    }
}
