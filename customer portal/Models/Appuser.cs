using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Appuser
    {
        [Key]
        public Guid? Id { get; set; }
        public string? UserName { get; set; }  
        public string? FullName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; } 
    }
}