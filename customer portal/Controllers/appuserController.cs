using Amazon.Auth.AccessControlPolicy;
using Azure.Messaging;
using customer_portal.Data;
using customer_portal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace customer_portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppuserController : Controller
    {
        private readonly cPDBContext cPDBContext;
        private readonly Guid appuserid;
        public AppuserController(cPDBContext cPDBContext)
        {
            this.cPDBContext = cPDBContext;
        }


        [HttpPost]
        [Route("Adduser")]
        public async Task<IActionResult> Addappuser([FromBody] Appuser appuser)

        {
            try
            {
                var existingUser = await cPDBContext.internportal_users.FirstOrDefaultAsync(u => u.UserName == appuser.UserName);
                if (existingUser != null)
                {
                    return Ok(new { Message = " Username not available. Please choose a different username." });
                }

                appuser.Id = Guid.NewGuid();
                await cPDBContext.internportal_users.AddAsync(appuser);
                await cPDBContext.SaveChangesAsync();
                return Ok(new { Message = "Success" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Get All login users
        [HttpPost]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Appuser appuser)
        {


            try
            {
                var existingUser = await cPDBContext.internportal_users.FirstOrDefaultAsync(u => u.UserName == appuser.UserName && u.Password == appuser.Password);
                if (existingUser != null)
                {
                    return Ok(new { Message = "Success", userid = existingUser.Id });
                }

                return Ok(new { Message = "Invalid!!" });

                                                                                                                                                                  
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpPost]
        [Route("AddPolicy")]
        public async Task<IActionResult> AddPolicy([FromBody] UserPolicyList body)
        {
            try
            {
                var policyExists = await cPDBContext.policy.FirstOrDefaultAsync(p => p.PolicyNumber == body.PolicyNumber);

                if (policyExists == null)
                {
                    return BadRequest(new { Message = "Invalid policy number" });
                }
                var existingUserPolicy = await cPDBContext.internportal_userpolicylist.FirstOrDefaultAsync(u => u.UserId == body.UserId && u.PolicyNumber == body.PolicyNumber);
                if (existingUserPolicy != null)
                {
                    return Ok(new { Message = "Policy already associated with the user." });
                }


                cPDBContext.internportal_userpolicylist.Add(body);
                await cPDBContext.SaveChangesAsync();

                return Ok(new { Message = "Policy added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }




        [HttpPost]
        [Route("RemovePolicy")]
         async Task<IActionResult> RemovePolicy([FromBody] UserPolicyList body)
        {
           try
           {
               var existingUserPolicy = await cPDBContext.internportal_userpolicylist.FirstOrDefaultAsync(u => u.UserId == body.UserId && u.PolicyNumber == body.PolicyNumber && u.ChasisNumber ==body.ChasisNumber);
               if (existingUserPolicy == null)
               {
                   return BadRequest(new { Message = "Policy not associated with the user." });
               }

              
                await cPDBContext.SaveChangesAsync();

                return Ok(new { Message = "Policy removed successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
           }
        }
        

        



        [HttpGet("getPolicies/{userid}")]
        public async Task<IActionResult>getPolicies([FromRoute] string userid)
        {
            try
            {
                var existingUserPolicy = await cPDBContext.internportal_userpolicylist.Where(u => u.UserId == userid ).ToListAsync();
                if (existingUserPolicy == null)
                {
                    return BadRequest(new { Message = "Policy associated with user." });
                }
                await cPDBContext.SaveChangesAsync();
                return Ok(existingUserPolicy);
            }
               catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }












        [HttpGet]
        [Route("PolicyDetails")]
        public async Task<IActionResult> PolicyDetails(string policyNumber)
        {
            try
            {
                var policyExists = await cPDBContext.policy.FirstOrDefaultAsync(p => p.PolicyNumber ==policyNumber);

                if (policyExists == null)
                {
                    return BadRequest(new { Message = "Invalid policy number" });
                }
                int? payplanid = policyExists.PayPlanId;
                var existingUserPolicy = await cPDBContext.payplan.FirstOrDefaultAsync(u => u.PayPlanId ==payplanid);
                if (existingUserPolicy == null)
                {
                    return Ok(new { Message = "Payplan id does not exist." });
                }

                var payplan = existingUserPolicy.PayPlan;
                var result = new { PolicyNumber = policyNumber,
                    PolicyEffectiveDt=policyExists.PolicyEffectiveDt,
                    PolicyExpirationDt=policyExists.PolicyExpirationDt,
                    Status=policyExists.Status,
                    TotalPremium=policyExists.TotalPremium,
                    PayPlan=payplan,

                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }









     [HttpGet]
     [Route("PolicyHolderDetails")]
      public async Task<IActionResult> PolicyHolderDetails(String PolicyNumber)
      {
    try
    {
        var policyExists = await cPDBContext.policy.FirstOrDefaultAsync(p => p.PolicyNumber == PolicyNumber);
        if (policyExists == null)
        {
          return BadRequest(new { Message = "Invalid policy number" });
        }
 
        var existingUserPolicy = await cPDBContext.policyinsured.FirstOrDefaultAsync(u => u.PolicyId == policyExists.policyId);
      if (existingUserPolicy == null)
        {
            return NotFound(new { Message = "Policy holder details not found" });
        }

        Guid insuredId = existingUserPolicy.InsuredId;
 
        var policyHolderDetails = await cPDBContext.insured.FirstOrDefaultAsync(i => i.InsuredId == insuredId);
       if (policyHolderDetails == null)
      {
            return NotFound(new { Message = "Policy holder details not found" });
        }
 
        Guid contactId = policyHolderDetails.ContactId;
 
        var contactDetails = await cPDBContext.contact.FirstOrDefaultAsync(c => c.ContactId == contactId);
        if (contactDetails == null)
        {
            return NotFound(new { Message = "Contact details not found" });
       }

            var result = new
             {
            FirstName = policyHolderDetails.FirstName,
            LastName = policyHolderDetails.LastName,
            AddressLine1 = contactDetails.AddressLine1,
            AddressLine2 = contactDetails.AddressLine2,
            City = contactDetails.City,
            State = contactDetails.State,
            PINCode = contactDetails.PINCode,
            MobileNo = contactDetails.MobileNo,
            Email = contactDetails.Email
            };
                return Ok(result);
   }
    catch (Exception ex)
    {
        return BadRequest(new { Message = ex.Message });
   }
}








        [HttpGet("GetCoverages/{PolicyNumber}")]
        public async Task<IActionResult> GetCoverages([FromRoute] string PolicyNumber)
        {
            try
            {
                var policyExists = await cPDBContext.policy.FirstOrDefaultAsync(p => p.PolicyNumber == PolicyNumber);

                if (policyExists == null)
                {
                    return BadRequest(new { Message = "Invalid policy number" });
                }

               Guid policyId = policyExists.policyId;

                var existingPolicyCoverage = await cPDBContext.policycoverage.FirstOrDefaultAsync(u => u.PolicyId==policyId);

                if (existingPolicyCoverage == null)
                {
                    return BadRequest(new { Message = "Policy coverage details not found" });
                }

                Guid coverageId = existingPolicyCoverage.CoverageId;

                var existingCoverage = await cPDBContext.coverage.FirstOrDefaultAsync(u => u.CoverageId == coverageId);

                if (existingCoverage == null)
                {
                    return BadRequest(new { Message = "Coverage details not found" });
                }


                return Ok(existingCoverage);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }










        [HttpGet]
        [Route("VehicleDetails")]
        public async Task<IActionResult> GetVehicleDetails(string policyNumber)
        {
            try
            {
                var policyExists = await cPDBContext.policy.FirstOrDefaultAsync(p => p.PolicyNumber == policyNumber);

                if (policyExists == null)
                {
                    return BadRequest(new { Message = "Invalid policy number" });
                }
                var vehicleDetails = await (from policy in cPDBContext.policy
                                            join policyVehicle in cPDBContext.policyvehicle on policy.policyId equals policyVehicle.PolicyId
                                            join vehicle in cPDBContext.vehicle on policyVehicle.VehicleId equals vehicle.VehicleId
                                            join brand in cPDBContext.brand on vehicle.BrandId equals brand.BrandId
                                            join model in cPDBContext.model on vehicle.ModelId equals model.ModelId.ToString()
                                            join variant in cPDBContext.variant on vehicle.VariantId equals variant.VariantId.ToString()
                                            join bodyType in cPDBContext.bodytype on vehicle.BodyTypeId equals bodyType.BodyTypeId.ToString()
                                            join fuelType in cPDBContext.fueltype on vehicle.FuelTypeId equals fuelType.FuelTypeId.ToString()
                                            join transmissionType in cPDBContext.transmissiontype on vehicle.TransmissionTypeId equals transmissionType.TransmissionTypeId.ToString()
                                            join rto in cPDBContext.rto on vehicle.RTOId equals rto.RTOId.ToString()
                                            where policy.PolicyNumber == policyNumber
                                            select new
                                            {
                                                vehicle.DateOfPurchase,
                                                Brand = brand.Brand,
                                                ModelName =model.modelname,
                                                Variant = variant.Variant,
                                                BodyType = bodyType.BodyType,
                                                FuelType = fuelType.FuelType,
                                                RTOName = rto.RTOName,
                                                RegistrationNumber = vehicle.RegistrationNumber,
                                                ChasisNumber =vehicle.chasisNumber,
                                                vehicle.EngineNumber,
                                                vehicle.YearOfManufacture,
                                                vehicle.IDV,
                                                vehicle.ExShowroomPrice
                                            }).FirstOrDefaultAsync();

                if (vehicleDetails == null)
                {
                    return NotFound(new { Message = "Vehicle details not found for the provided policy number" });
                }

                return Ok(vehicleDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        


































    }

}

      






























    

















































