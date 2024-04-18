using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class PayPlans
    {[Key]
        public int PayPlanId { get; set; }
        public string PayPlan { get; set;}
        public string Description { get; set;}
        public bool IsActive { get; set; }

    }
}
