using BlogTeste2.DAL;
using BlogTeste2.Models;
using System.Linq;
using System.Web.Mvc;

namespace BlogTeste2.Areas.Admin.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostDAO dao;

        public PostController(PostDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            var lista = dao.TodosPosts().ToList();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Adiciona(post);
                return RedirectToAction("Index");
            } else
            {
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = dao.BuscaPorId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Atualiza(post);
                return RedirectToAction("Index");
            } else
            {
                return View(post);
            }
        }

        public ActionResult Remover(int id)
        {
            dao.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Publicar(int id)
        {
            dao.Publica(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            var model = dao.TodosPosts().ToList()
                .Where(p => p.Categoria.Contains(term))
                .Select(p => new { label = p.Categoria })
                .Distinct();
            return Json(model);
        }
    }
}