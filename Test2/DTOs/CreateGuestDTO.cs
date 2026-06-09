using System.ComponentModel.DataAnnotations;

namespace Test2.DTOs;

public class CreateGuestDTO
{
    [Required] [MaxLength(50)] 
    public string FirstName { get; set; } = null!;

    [Required] [MaxLength(100)] 
    public string LastName { get; set; } = null!;

    [Required] [MaxLength(100)] 
    public string Email { get; set; } = null!;

    [Required] [MaxLength(9)] 
    public string Phone { get; set; } = null!;

    public ReservationCreatDTO Reservation { get; set; } = null!;
}
public class ReservationCreatDTO
{
    public int RoomID { get; set; }
    public DateTime CheckInDate {get; set; }
}