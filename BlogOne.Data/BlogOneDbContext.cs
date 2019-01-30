using System;
using System.Collections.Generic;
using System.Text;
using BlogOne.Core;
using Microsoft.EntityFrameworkCore;

namespace BlogOne.Data
{
    public class BlogOneDbContext : DbContext
    {
        public BlogOneDbContext(DbContextOptions<BlogOneDbContext> options) : base(options)
        {
            
        }

        public DbSet<BlogDetails> BlogDetails { get; set; }
    }
}
