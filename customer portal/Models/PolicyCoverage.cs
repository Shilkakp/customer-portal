using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    
    public class PolicyCoverage
    {
        [Key]
        public string? PolicyCoverageId { get; set; }

        public Guid PolicyId { get; set; }
        public Guid CoverageId { get; set; }
        public int? Limit { get; set; } 
        public decimal? Premium { get; set; }    
        public string? MasterTableId { get; set; }
        public string? TransId { get; set;}
        public DateOnly? ModifiedDate { get; set; }  
        public int? UserId { get; set; }
        public DateOnly? CoverageEffectiveDt { get; set; }   
        public DateOnly? OrginalCoverageEffectiveDt { get; set; }    
        public int? DeletedInd {  get; set; }
        public DateOnly? deletedDate { get; set; }










    }
}
