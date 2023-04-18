using AppAPI.Data;
using AppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly DataContext _context;

        public UserController(DataContext context) {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get() {
            return Ok(await _context.Users.ToListAsync());
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> Get(int id) {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null) {
                return BadRequest("User not found!");
            }
            return Ok(dbUser);

        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<List<User>>> Post(User user) {
            var users = await _context.Users.ToListAsync();
            foreach(User dbUser in users)
            {
                if (dbUser.Email == user.Email)
                {
                    return BadRequest("The email is used by another user!");
                }
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.SaveChangesAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> Update(User user) {
            var dbUser = await _context.Users.FindAsync(user.UserId);
            if (dbUser == null) {
                return BadRequest("User not found!");
            }

            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.Password = user.Password;
            dbUser.IsAdmin = user.IsAdmin;

            await _context.SaveChangesAsync();

            return Ok(await _context.SaveChangesAsync());
        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Remove(int id) {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null) return BadRequest("User not found!");
            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.SaveChangesAsync());
        }
    }
}
