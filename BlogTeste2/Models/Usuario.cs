using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace BlogTeste2.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime UltimoLogin { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}