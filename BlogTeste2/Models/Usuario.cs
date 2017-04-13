using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace BlogTeste2.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime UltimoLogin { get; set; }
    }
}