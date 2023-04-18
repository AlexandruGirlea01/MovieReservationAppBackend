using AppAPI.Data;
using AppAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {

        private readonly DataContext _context;

        public LoginController(DataContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(Login user)
        {
            var users = await _context.Users.ToListAsync();
            foreach (User u in users)
            {
                if (u.Email == user.Email)
                {
                    if (u.Password == user.Password)
                    {
                        return Ok(u);
                    }
                    else
                    {
                        return BadRequest("Wrong password!");
                    }
                }

            }
            return NotFound("There is no user with that email!");
        }
    }
}
