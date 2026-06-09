using Test2.Data;
using Test2.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test2.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/guests")]
        public async Task<IActionResult> GetRoomGuests(int id)
        {
            var room = await _context.Rooms
                .FirstOrDefaultAsync(x => x.RoomId == id);

            if(room is null)
            {
                return NotFound("Room not found");
            }

            var reservations = await _context.Reservations
                .Where(r => r.RoomId == id)
                .Select(r => new ReservationInfoDTO
                {
                    ReservationId = r.ReservationId,
                    CheckInDate = r.CheckInDate,
                    CheckOutDate = r.CheckOutDate,
                    Status = r.Status,
                    Guest = new GuestInfoDTO
                    {
                        FirstName = r.Guest.FirstName,
                        LastName = r.Guest.LastName,
                        Email = r.Guest.Email,
                        Phone = r.Guest.Phone
                    },
                    ReservationServices = r.ReservationServices.Select(rs => new ReservationServiceInfoDTO
                    {
                        Quantity = rs.Quantity,
                        ServiceDate = rs.ServiceDate,
                        Service = new ServiceInfoDTO
                        {
                            ServiceId = rs.Service.ServiceId,
                            Name = rs.Service.Name,
                            Description = rs.Service.Description,
                            Price = rs.Service.Price,
                            DurationMinutes = rs.Service.DurationMinutes
                        }
                    }).ToList()
                })
                .ToListAsync();

            var result = new RoomHistoryDTO
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                Type = room.Type,
                PricePerNight = room.PricePerNight,
                Floor = room.Floor,
                Reservations = reservations
            };

            return Ok(result);
        }
    }
}