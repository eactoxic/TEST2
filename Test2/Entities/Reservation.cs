using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Reservation
{
    public int ReservationId { get; set; }
    
    public DateTime CheckInDate { get; set; }
    
    public DateTime CheckOutDate { get; set; }

    [MaxLength(50)] 
    public string Status { get; set; } = null!;

    public int GuestId {get; set; }
    public Guest Guest { get; set; } = null!;
    
    public int RoomId { get; set; }
    public Room Room { get; set; } = null!;

    public ICollection<ReservationService> ReservationServices { get; set; } = new List<ReservationService>();


}