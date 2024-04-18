using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class PolicyInsured
    {
        [Key]
        public Guid PolicyId { get; set; } 
        public Guid InsuredId { get; set; }
        public Guid TransId { get; set; }

    }
}
