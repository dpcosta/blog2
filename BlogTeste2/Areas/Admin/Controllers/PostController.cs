using BlogTeste2.Infra;
using BlogTeste2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTeste2.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private BlogContext contexto;

        public PostController()
        {
            this.contexto = new BlogContext();
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            var lista = contexto.Posts.ToList();
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
                contexto.Posts.Add(post);
                contexto.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View(post);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = contexto.Posts.Where(p => p.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                return View(post);
            }
        }

        public ActionResult Remover(int id)
        {
            var postAExcluir = contexto.Posts.Where(p => p.Id == id).FirstOrDefault();
            contexto.Posts.Remove(postAExcluir);
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Publicar(int id)
        {
            var postAPublicar = contexto.Posts.Where(p => p.Id == id).FirstOrDefault();
            postAPublicar.Publicado = true;
            postAPublicar.DataPublicacao = DateTime.Now;
            contexto.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            var model = contexto.Posts.ToList()
                .Where(p => p.Categoria.Contains(term))
                .Select(p => new { label = p.Categoria })
                .Distinct();
            return Json(model);
        }
    }
}