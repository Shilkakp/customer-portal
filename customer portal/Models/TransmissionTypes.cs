using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class TransmissionTypes
    {
        [Key]
        public int TransmissionTypeId { get; set; }
        public string TransmissionType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
