using BlogTeste2.DAL;
using System.Linq;
using System.Web.Mvc;

namespace BlogTeste2.Controllers
{
    public class HomeController : Controller
    {
         private PostDAO dao;

        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            var lista = dao.PostsMaisRecentes().Where(p=>p.Publicado).ToList();
            return View(lista);
        }

         public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            var lista = from p in dao.PostsMaisRecentes() where p.Categoria.Contains(categoria) select p;
            return View("Index", lista.ToList());
        }

        public ActionResult Busca(string termo)
        {
            var model = dao.PostsMaisRecentes()
                .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                .Select(p => p)
                .ToList();
            return View("Index", model);
        }

    }
}