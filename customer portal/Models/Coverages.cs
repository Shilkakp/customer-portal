using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Coverages
    {
        [Key]
        public Guid CoverageId { get; set; }
        public string CoverageName { get; set;}
        public string CovCd { get; set;}
        public DateOnly EffectiveDt { get; set; }   
        public DateOnly ExpirationDt { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set;}
        public bool IsActive {  get; set; }
    }
}
