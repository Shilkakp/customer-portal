using customer_portal.Data;
using customer_portal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.PowerBI.Api.Models;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<IActionResult>Authenticate([FromBody] Appuser appuser)
        {

            
            try
            {
                var existingUser = await cPDBContext.internportal_users.FirstOrDefaultAsync(u => u.UserName == appuser.UserName);
                if (existingUser != null)
                {
                    return Ok(new { Message = "Success" });
                }
                
                return Ok(new { Message = "Invalid user" });

               
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  

        }
        [HttpPost]
        [Route("logout")]
        public IActionResult logout()
        {
           
            return Ok(new { message = "logged out" });
        }

    }
}


