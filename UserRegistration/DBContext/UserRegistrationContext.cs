using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;

namespace UserRegistration.DBContext
{
    public class UserRegistrationContext: DbContext
    {
        public UserRegistrationContext(DbContextOptions<UserRegistrationContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
