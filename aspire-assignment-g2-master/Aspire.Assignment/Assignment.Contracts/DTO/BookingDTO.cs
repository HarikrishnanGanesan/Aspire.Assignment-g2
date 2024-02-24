using Microsoft.AspNetCore.Http;

namespace Assignment.Contracts.DTO
{
    public class BookingDTO
    {
        public string? RegistrationNumber { get; set; }
        public required string? CustomerName { get; set; }
        public required string? MobileNumber { get; set; }
        public required DateTime PickupDateTime { get; set; }
        public required DateTime ReturnDateTime { get; set; }
        public required string? PickupLocation { get; set; }
        public required string? DropLocation { get; set; }
        public required string? ShippingType { get; set; }
        public string? PaymentMode { get; set; }
        public string? PaymentStatus { get; set; }
        public required string? DLNumber { get; set; }

        public IFormFile? DLImageFileFront { get; set; }
        public byte[]? DLImageFront { get; set; }
        public byte[]? DLImageBack { get; set; }
        public IFormFile? DLImageFileBack { get; set; }
        //public DateTime BookedDateTime { get; set; } = DateTime.Now;
        //public string? BookingStatus { get; set; }="Pending";
    }
}