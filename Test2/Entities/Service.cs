using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Service
{
    public int ServiceId { get; set; }

    [MaxLength(100)] 
    public string Name { get; set; } = null!;

    [MaxLength(200)] 
    public string Description { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    public int DurationMinutes { get; set; }
    
    public ICollection<ReservationService> ReservationServices { get; set; } = new List<ReservationService>();

}