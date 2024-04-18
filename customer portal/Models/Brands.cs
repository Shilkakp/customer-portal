using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Brands
    {
        [Key]
        public string? BrandId { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? Brand { get; set; }
        public string? Description { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
