using AppAPI.Data;
using AppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionController : ControllerBase {

        private readonly DataContext _context;

        public ProjectionController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<ProjectionController>
        [HttpGet]
        public async Task<ActionResult<List<Projection>>> Get()
        {
            return Ok(await _context.Projections.ToListAsync());
        }

        // GET api/<ProjectionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Projection>>> Get(int id)
        {
            var dbProjection = await _context.Projections.FindAsync(id);
            if (dbProjection == null)
            {
                return BadRequest("Projection not found!");
            }
            return Ok(dbProjection);

        }

        // POST api/<ProjectionController>
        [HttpPost]
        public async Task<ActionResult<List<Projection>>> Post(Projection projection)
        {
            _context.Projections.Add(projection);
            await _context.SaveChangesAsync();
            return Ok(await _context.SaveChangesAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Projection>>> Update(Projection projection)
        {
            var dbProjection = await _context.Projections.FindAsync(projection.ProjectionId);
            if (dbProjection == null)
            {
                return BadRequest("Projection not found!");
            }
            dbProjection.Name = projection.Name;
            dbProjection.Description = projection.Description;
            dbProjection.Genre = projection.Genre;
            dbProjection.Rating = projection.Rating;

            await _context.SaveChangesAsync();

            return Ok(await _context.SaveChangesAsync());
        }
        

        // DELETE api/<ProjectionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Projection>>> Remove(int id)
        {
            var dbProjection = await _context.Projections.FindAsync(id);
            if (dbProjection == null) return BadRequest("Projection not found!");
            _context.Projections.Remove(dbProjection);
            await _context.SaveChangesAsync();

            return Ok(await _context.SaveChangesAsync());
        }
    }
}
