using System.Collections.Generic;
using System.Data.Entity;
using System.Web.UI;

namespace Test3Task.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}