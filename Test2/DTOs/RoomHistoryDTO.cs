namespace Test2.DTOs;

public class RoomHistoryDTO
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = null;
    public string Type { get; set; } = null!;
    public decimal PricePerNight { get; set; }
    public int Floor { get; set; }
    public List<ReservationInfoDTO> Reservations { get; set; } = new List<ReservationInfoDTO>();
}
public class ReservationInfoDTO
{
    public int ReservationId { get; set; }
    public GuestInfoDTO Guest { get; set; } = null!;
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public string Status { get; set; } = null!;
    public List<ReservationServiceInfoDTO> ReservationServices { get; set; } = new List<ReservationServiceInfoDTO>();
}
public class GuestInfoDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
public class ReservationServiceInfoDTO
{
    public int Quantity { get; set; }
    public DateTime ServiceDate { get; set; }
    public ServiceInfoDTO service { get; set; } = null!;
}

public class ServiceInfoDTO
{
    public int ServiceId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int DurationMinutes { get; set; }
}