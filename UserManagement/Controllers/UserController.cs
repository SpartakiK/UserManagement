using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.DataModels;
using UserManagement.Application.Services;
using UserManagement.Domain.IRepositories;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<UserDto> Get(int userId)
        {
            var user = await _userService.GetByIdAsync(2);
            return user;
        }
    }
}