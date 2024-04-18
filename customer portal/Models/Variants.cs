using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Variants
    {
        [Key]
        public int VariantId { get; set; }
        public string Variant { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
