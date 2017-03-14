using BlogTeste2.Models;
using System.Data.Entity;

namespace BlogTeste2.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("name=blog")
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}