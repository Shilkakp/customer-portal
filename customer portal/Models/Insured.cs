using System.ComponentModel.DataAnnotations;

namespace customer_portal.Models
{
    public class Insured
    {
        [Key]
        public Guid InsuredId { get; set; }
        public int UserTypeId { get; set; } 
        public Guid ContactId { get; set; }
        public string FirstName {  get; set; }   
        public string LastName { get; set; }
        public string AadharNumber { get; set; }  
        public string LicenseNumber { get; set; }
        public string PANNumber { get; set; }                                  
        public string AccountNumber { get; set; } 
    
        public string IFSCCode { get; set; }    
        public string BankName { get; set; }  
        public string BankAddress { get; set; }  
        public DateOnly ModifiedDate { get; set; } 
        public int UserId { get; set; }
        


                                        
     
    }
}
