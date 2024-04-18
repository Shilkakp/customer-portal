namespace customer_portal.Models
{
    public class InstallmentDetails
    {
        public string InstDetailId{ get; set; }
        public int InstallmentNumber { get; set; }
        public DateOnly DueDt { get; set; }
        public decimal PremiumDue { get; set; }
        public string Status { get; set; }
        public string PolicyNumber { get; set; }
        public string Note { get; set; }
        public string BillDate { get; set; }
    }
}
