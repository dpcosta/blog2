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
                var lista = contexto.Posts.Where(p=>p.Publicado).ToList();
                return View(lista);
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