using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Policy
    {
        [Key]
       public Guid policyId { get; set; }
        public int AppUserId { get; set; }
        public string? PolicyNumber { get; set; }
        public string? QuoteNumber { get; set;}
        public DateOnly? PolicyEffectiveDt { get; set;}
        public DateOnly? PolicyExpirationDt { get; set;} 
        public string? Status { get; set;}
        public int? Term { get; set;}
        public DateOnly? RateDt { get; set;}
        public decimal?  TotalPremium { get;set;}
        public decimal? SGST { get; set;}
        public decimal?  CGST { get; set;}
        public decimal? IGST { get; set;}
        public decimal? TotalFees { get; set;}
        public string? PaymentType { get;set;}
        public string? ReceiptNumber { get; set;}
        public bool? EligibleForNCB { get;set;}
        public int? PayPlanId { get; set;}
        public int? BillPaidBy { get; set;}
        public string? LastTransCd { get; set;}
        public DateOnly? TransactionEffectiveDate { get;set;}
        public decimal? PriorTransPremium { get; set;}
        public string? policyStatus { get; set;}
        public string? Description { get; set;}
        public string? MasterTableId { get; set;}
        public string? TransId { get; set;}
        public bool? InstallGeneratedIndicator { get; set;}
        public DateTime? ModifiedDate { get; set;}
        public int? UserId { get; set;}
        public decimal? RefundAmt { get; set;}
        public bool? RefundPaidIndicator { get; set;}
        public DateTime? RefundDate { get; set;}
    }
}
