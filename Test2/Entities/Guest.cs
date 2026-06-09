using System.ComponentModel.DataAnnotations;

namespace Test2.Entities;

public class Guest
{
    public int GuestId { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public string Email { get; set; }
    
    [MaxLength(9)]
    public string Phone { get; set; }
}