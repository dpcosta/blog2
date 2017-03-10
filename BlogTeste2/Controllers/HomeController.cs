﻿using BlogTeste2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var lista = new List<Post>();
            string stringConexao = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            using (SqlConnection cnx = new SqlConnection(stringConexao))
            {
                cnx.Open();
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
            }
            return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            using (SqlConnection cnx = new SqlConnection(stringConexao))
            {
                cnx.Open();
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "insert into Posts (titulo, resumo, categoria) values (@titulo, @resumo, @categoria)";
                comando.Parameters.Add(new SqlParameter("titulo", post.Titulo));
                comando.Parameters.Add(new SqlParameter("resumo", post.Resumo));
                comando.Parameters.Add(new SqlParameter("categoria", post.Categoria));
                comando.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}