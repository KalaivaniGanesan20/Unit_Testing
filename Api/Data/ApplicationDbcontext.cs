using Microsoft.EntityFrameworkCore;
using UserModel;
namespace Database
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options)
        {

        }
        public DbSet<User> myuser{get;set;}
    }
}