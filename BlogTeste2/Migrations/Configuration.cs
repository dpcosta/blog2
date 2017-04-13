namespace BlogTeste2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogTeste2.Infra.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogTeste2.Infra.BlogContext context)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("admin");
            Usuario usuarioAdmin = new Usuario
            {
                UserName = "admin",
                PasswordHash = password,
                UltimoLogin = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            context.Users.AddOrUpdate(u => u.UserName, usuarioAdmin);
        }
    }
}
