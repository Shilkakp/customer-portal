using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class BodyTypes
    {
        [Key]
        public int BodyTypeId{ get; set; }
        public string BodyType { get; set; }
        public string Description { get; set; }
        public bool IsActive {  get; set; }
    }
}
