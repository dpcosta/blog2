using BlogTeste2.Infra;
using BlogTeste2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTeste2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (BlogContext contexto = new BlogContext())
            {
                var lista = contexto.Posts.ToList();
                return View(lista);
            }
        }

        public ActionResult NovoPost()
        {
            var model = new Post();
            return View(model);
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
             if (ModelState.IsValid)
            {
                using (BlogContext contexto = new BlogContext())
                {
                    contexto.Posts.Add(post);
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            } else
            {
                return View("NovoPost", post);
            }
        }

        public ActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            using (BlogContext contexto = new BlogContext())
            {
                //var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                var lista = from p in contexto.Posts where p.Categoria.Contains(categoria) select p;
                return View("Index", lista.ToList());
            }
        }

        public ActionResult RemovePost(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult PublicaPost(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Visualiza(int id)
        {
            using (var contexto = new BlogContext())
            {
                var post = contexto.Posts.Find(id);
                 return View(post);
            }
        }

        [HttpPost]
        public ActionResult EditaPost(Post post)
        {
            if (ModelState.IsValid)
            {
                using (var contexto = new BlogContext())
                {
                    contexto.Entry(post).State = EntityState.Modified;
                    contexto.SaveChanges();
                    return RedirectToAction("Index");
                }
            } else
            {
                return View("Visualiza", post);
            }
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            using (var contexto = new BlogContext())
            {
                var model = contexto.Posts.ToList()
                    .Where(p => p.Categoria.Contains(term))
                    .Select(p => new { label = p.Categoria })
                    .Distinct();
                return Json(model);
            }
        }

        public ActionResult Busca(string termo)
        {
            using (var contexto = new BlogContext())
            {
                var model = contexto.Posts
                    .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                    .Select(p => p)
                    .ToList();
                return View("Index", model);
            }
        }
    }
}