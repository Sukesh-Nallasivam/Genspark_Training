using Microsoft.EntityFrameworkCore;
using PizzaStore.Models;

namespace PizzaStore.Contexts
{
    public class PizzaStoreDBContext:DbContext
    {
        public PizzaStoreDBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Pizza> pizzas { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }
    }
}
