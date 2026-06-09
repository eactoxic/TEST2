using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Room
{
    public int RoomId { get; set; }

    [MaxLength(10)] 
    public string RoomNumber { get; set; } = null!;

    [MaxLength(50)] 
    public string Type { get; set; } = null!;
    
    public decimal PricePerNight { get; set; }
    
    public int Floor { get; set; }
    
    public ICollection<Reservation> Reservations { get; set; } =  new List<Reservation>();

}