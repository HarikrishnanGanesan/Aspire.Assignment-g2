using System.ComponentModel.DataAnnotations;
namespace Assignment.Contracts.Data.Entities;
public class CarDetails{
    [Key]
    public required string RegistrationNumber { get; set; }
    public required string ManufacturerName { get; set; }
    public required string Model { get; set; }
    public  required int ModelYear { get; set; }
    public required int PassengerCapacity { get; set; }
    public required string Colour { get; set; }
    public required string TransmissionType { get; set; }
    public required string FuelType { get; set; }
    public required bool HasAC { get; set; }
    public required int Mileage { get; set; }
    public required byte[] ImageData { get; set; }
    public required int KilometersDriven { get; set; }
    public required decimal PricePerDay { get; set; }
    public required decimal PricePerHour { get; set; }
    public required decimal PricePerWeek { get; set; }
    public required string Available { get; set; }
    public required string Description { get; set; }
 
    }
