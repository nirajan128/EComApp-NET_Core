using E_Web_NET_CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Web_NET_CORE.Data
{
    //Must implement DbContext class from entity framework, which is the root class
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //whatever option that are passed to option is passsed to base class of dbcontext
        {
            
        }

        //Creates aproperty of generic DbSet Category class type
        //which creates a table
        //TO ADD TABLE TO DATABASE USE [ ADD-MIGRATION, MEANING FUL NAME] COMMAND IN NUGET PACKAGE MANAGER TERMINAL
        //nOW ENTER UPDATE-DATABASE TO APPLY THE MIGRATION TO THE DATABASE WHICH WILL ADD THE THE TABLE
        public DbSet<Category> Categories { get; set; }
    }
}
