using customer_portal.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_portal.Data
{
    public class cPDBContext : DbContext
    {
        //Dbset

        public DbSet<Appuser> internportal_users{ get; set; }
        public DbSet<UserPolicyList> internportal_userpolicylist { get; set; }
        public DbSet<Policy> policy {  get; set; }
        public DbSet<Policyvehicle> policyvehicle { get; set; } 
        public DbSet<Vehicle> vehicle { get; set; }
        public DbSet<PayPlans> payplan { get; set; }
        public DbSet<PolicyInsured> policyinsured { get; set; }
        public DbSet<Insured> insured { get; set; }
        public DbSet<Contact> contact { get; set; }
        public DbSet<Coverages> coverage { get; set; }
        public DbSet<PolicyCoverage> policycoverage { get; set; } 
        public DbSet<VehicleTypes> vehicletype { get; set; }
        public DbSet<Rto>rto { get; set; }  
        public DbSet<Brands> brand{ get; set; }
        public DbSet<Model>model { get; set; } 
        public DbSet<Variants> variant { get; set; }
        public DbSet<BodyTypes> bodytype { get; set; }
        public DbSet<FuelTypes> fueltype { get; set; }
        public DbSet<TransmissionTypes> transmissiontype { get; set; }
        public object Registers { get; internal set; }
        public object PolicyNumber { get; internal set; }
        public object Coverages { get; internal set; }
        public object InstallmentDetails { get; internal set; } 

        public cPDBContext(DbContextOptions options) : base(options)
        {
        }

        internal Task Register()
        {
            throw new NotImplementedException();
        }
    }
}
