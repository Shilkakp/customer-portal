using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PINCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public DateOnly ModifiedDate { get; set; }
        public int UserId { get; set; }


    }
}
