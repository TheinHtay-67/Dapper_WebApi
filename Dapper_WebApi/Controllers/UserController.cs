using Dapper_WebApi.DTO;
using Dapper_WebApi.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            try
            {
                var createdUser = await _userRepository.CreateUser(user);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
