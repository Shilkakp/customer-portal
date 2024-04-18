using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleId {  get; set; }
        public string? VehicleTypeID { get; set; }
        public string? RTOId { get; set; }
        public string?  BrandId { get; set; }
        public string? ModelId { get; set; }
        public string? VariantId { get; set; }
        public string? BodyTypeId { get; set; }
        public string? TransmissionTypeId { get; set; }
        public string? RegistrationNumber{ get; set; }
        public DateOnly DateOfPurchase { get; set; }
        public string? Color {  get; set; }
        public string? chasisNumber{ get; set; }
        public string?  EngineNumber{ get; set; }
        public string? CubicCapacity { get; set;}
        public string? SeatingCapacity { get; set;}
        public string? MonthOfManufacture { get; set;}
        public string? YearOfManufacture { get; set; }
        public decimal IDV {  get; set; }
        public decimal ExShowroomPrice { get; set;}
        public string? FuelTypeId { get; set;}
        public string? MasterTableId { get; set; }
        public string? TransId { get; set; }
        public decimal IDVDepreciationRate { get; set;}
        public DateTime? ModifiedDate { get; set;}
        public string? UserId { get; set; }
    }
}
