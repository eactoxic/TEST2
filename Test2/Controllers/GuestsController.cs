using Test2.Data;
using Test2.DTOs;    
using Test2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test2.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class GuestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GuestsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] CreateGuestDTO dto)
        {
            var room = await _context.Rooms
                .FirstOrDefaultAsync(x => x.RoomId == dto.Reservation.RoomId);

            if(room is null)
            {
                return NotFound("Room not found");
            }

            if (dto.Reservation.CheckInDate.Date < DateTime.Now.Date)
            {
                return BadRequest("Check-in date cannot be in the past");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            var guest = new Guest
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            var reservation = new Reservation
            {
                GuestId = guest.GuestId,
                RoomId = dto.Reservation.RoomId,
                CheckInDate = dto.Reservation.CheckInDate,
                Status = "Confirmed"
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Created("", new { guestId = guest.GuestId });
        }
    }
}