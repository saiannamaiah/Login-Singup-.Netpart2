using AngularNew.Context;
using AngularNew.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppdbContext _authContext;
        public UserController(AppdbContext appdbContext)
        {
            _authContext = appdbContext;
            }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]  User userObj)
        {
            if (userObj == null)
                return BadRequest();
            var user= await _authContext.Users.FirstOrDefaultAsync(x=> x.Username == userObj.Username && x.Password == userObj.Password);
            if (user == null)
                return NotFound(new { Message = "User not found!" });
            return Ok(new
            {
                Message = "Login Success!"
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisteredUser([FromBody] User userObj)
        {
            if(userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
                await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered!"
            });
        }
    }
}
