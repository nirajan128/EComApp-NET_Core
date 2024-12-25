using Microsoft.EntityFrameworkCore;

namespace E_Web_NET_CORE.Data
{
    //Must implement DbContext class from entity framework, which is the root class
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //whatever option that are passed to option is passsed to base class of dbcontext
        {
            
        }
    }
}
