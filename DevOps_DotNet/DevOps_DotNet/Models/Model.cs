using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps_DotNet.Models
{
    public class Model
    {
        public class DevOps_DotNetContext : DbContext
        {
            public DevOps_DotNetContext(DbContextOptions<DevOps_DotNetContext> options)
                : base(options)
            { }

            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }

            public DbSet<Hoge> Hoge { get; set; }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }

            public ICollection<Post> Posts { get; set; }
        }

        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }
            public Blog Blog { get; set; }
        }
    }
}
