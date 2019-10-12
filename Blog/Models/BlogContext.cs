using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("DbConnection")
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Posts> Post { get; set; }
        
        public DbSet<Comment> Comments { get; set; }

    }
}