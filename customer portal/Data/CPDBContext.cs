using customer_portal.Models;
using Microsoft.EntityFrameworkCore;

namespace customer_portal.Data
{
    public class cPDBContext : DbContext
    {
        //Dbset

        public DbSet<Appuser> internportal_users{ get; set; }
        public object Registers { get; internal set; }

        public cPDBContext(DbContextOptions options) : base(options)
        {
        }

        internal Task Register()
        {
            throw new NotImplementedException();
        }
    }
}
