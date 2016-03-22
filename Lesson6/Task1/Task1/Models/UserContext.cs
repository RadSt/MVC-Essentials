using System;
using System.Data.Entity;

namespace Task1.Models
{
    public class UserContext:DbContext
    {
        public UserContext()
            : base("UserConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}