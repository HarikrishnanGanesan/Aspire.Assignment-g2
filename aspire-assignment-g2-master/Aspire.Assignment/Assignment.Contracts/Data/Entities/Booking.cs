using System.ComponentModel.DataAnnotations;
namespace Assignment.Contracts.Data.Entities;
public class Booking
{
    [Key]
    public int BookingId { get; set; }
    public string? RegistrationNumber { get; set; }
    public required string? CustomerName { get; set; }
    public required string? MobileNumber { get; set; }
    public required DateTime PickupDateTime { get; set; }
    public required DateTime ReturnDateTime { get; set; }
    public DateTime BookedDateTime { get; set; } = DateTime.Now;
    public required string? PickupLocation { get; set; }
    public required string? DropLocation { get; set; }
    public required string? ShippingType { get; set; }
    public string? PaymentMode { get; set; }
    public string? PaymentStatus { get; set; }
    public required string? DLNumber { get; set; }
    public byte[]? DLImageFront { get; set; }
    public byte[]? DLImageBack { get; set; }
    public string? BookingStatus { get; set; }="Pending";
    
}
