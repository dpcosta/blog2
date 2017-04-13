using BlogTeste2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace BlogTeste2.Infra
{
    public class BlogContext : IdentityDbContext<Usuario>
    {
        public BlogContext() : base("name=blog")
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}