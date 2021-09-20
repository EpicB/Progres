using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.PostgreSQL
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=users;Username=postgres;Password=151515");
    }

    public class users
    {
        public int userid { get; set; }
        public int user_type { get; set; }
        public string username { get; set; }
    }

    public class courses
    {
        public int courseid { get; set; }
        public int creation_time { get; set; }
        public int course_time { get; set; }
        public int userid { get; set; }
    }
}
