using BlogTeste2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogTeste2.Infra
{
    public class UsuarioManager : UserManager<Usuario>
    {
        public UsuarioManager(IUserStore<Usuario> store) : base(store)
        {
        }

        public static UsuarioManager Create()
        {
            var userStore = new UserStore<Usuario>(new BlogContext());
            return new UsuarioManager(userStore);
        }
    }
}