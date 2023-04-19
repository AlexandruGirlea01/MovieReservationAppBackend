using AppAPI.Data;
using AppAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase {

        private readonly DataContext _context;

        public ReservationController(DataContext context) {
            _context = context;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> Get() {
            return Ok(await _context.Reservations.ToListAsync());
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Reservation>>> Get(int id) {
            var dbReservation = await _context.Reservations.FindAsync(id);
            if (dbReservation == null) {
                return BadRequest("Reservation not found!");
            }
            return Ok(dbReservation);

        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<ActionResult<List<Reservation>>> Post(Reservation reservation) {
            var reservations = await _context.Reservations.ToListAsync();
            foreach (Reservation dbReservation in reservations) {
                if (dbReservation.UserId == reservation.UserId && 
                    dbReservation.ProjectionId == reservation.ProjectionId && 
                    dbReservation.SeatNumber == reservation.SeatNumber) {

                    return BadRequest("The email is used by another user!");
                }
            }
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return Ok(await _context.SaveChangesAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Reservation>>> Update(Reservation reservation) {
            var dbReservation = await _context.Reservations.FindAsync(reservation.ReservationId);
            if (dbReservation == null) {
                return BadRequest("Reservation not found!");
            }

            dbReservation.ProjectionId = reservation.ProjectionId;
            dbReservation.SeatNumber = reservation.SeatNumber;
            dbReservation.UserId = reservation.UserId;
            await _context.SaveChangesAsync();

            return Ok(await _context.SaveChangesAsync());
        }


        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Reservation>>> Remove(int id) {
            var dbReservation = await _context.Reservations.FindAsync(id);
            if (dbReservation == null) return BadRequest("Reservation not found!");
            _context.Reservations.Remove(dbReservation);
            await _context.SaveChangesAsync();

            return Ok(await _context.SaveChangesAsync());
        }
    }
}
