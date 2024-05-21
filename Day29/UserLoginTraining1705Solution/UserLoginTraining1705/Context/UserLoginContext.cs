using Microsoft.EntityFrameworkCore;
using RequestTracker.Models;
using UserLoginTraining1705.Models;

namespace UserLoginTraining1705.Context
{
    public class UserLoginContext : DbContext
    {
        public UserLoginContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Security> securities { get; set; }
        public DbSet<Request> requests { get; set; }
        public DbSet<Solution> solutions { get; set; }
    }
}
