using BlogTeste2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTeste2.Controllers
{
    public class HomeController : Controller
    {
        private IList<Post> lista;

        public HomeController()
        {
            lista = new List<Post>
            {
                new Post { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
                new Post { Titulo = "Cassino Royale", Resumo = "007", Categoria = "Filme" },
                new Post { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria = "Livro" },
                new Post { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            lista.Add(post);
            return View("Index", lista);
        }
    }
}