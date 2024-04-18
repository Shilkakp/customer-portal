namespace customer_portal.Models
{
    public class Rto
    {
        public int RTOId { get; set; }
        public string RTOName { get; set; }
        public string City { get; set; }
        public string State { get; set; } 
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
