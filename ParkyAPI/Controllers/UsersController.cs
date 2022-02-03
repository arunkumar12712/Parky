using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepository;

namespace ParkyAPI.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/users")]
   
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userRepo.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "username or password incorrect" });
            }

            return Ok(user);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthenticationModel model)
        {
            var ifUserNameUnique = _userRepo.IsUniqueUser(model.Username);
            if (!ifUserNameUnique)
            {
                return BadRequest(new { message = "username aleady exists" });
            }
            var user = _userRepo.Register(model.Username, model.Password);
            if(user == null)
            {
                return BadRequest(new { message = "error while registering" });
            }
            return Ok();

        }

    }
}
