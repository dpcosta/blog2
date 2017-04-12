using BlogTeste2.Infra;
using BlogTeste2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogTeste2.DAL
{
    public class PostDAO
    {
        private BlogContext contexto;

        public PostDAO()
        {
            this.contexto = new BlogContext();
        }

        public IEnumerable<Post> PostsMaisRecentes()
        {
            return contexto.Posts.OrderByDescending(p => p.DataPublicacao);
        }

        public IEnumerable<Post> TodosPosts()
        {
            return contexto.Posts;
        }

        public void Adiciona(Post p)
        {
            contexto.Posts.Add(p);
            contexto.SaveChanges();
        }

        public void Atualiza(Post p)
        {
            contexto.Entry(p).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Remove(int id)
        {
            var post = BuscaPorId(id);
            contexto.Posts.Remove(post);
            contexto.SaveChanges();
        }

        public Post BuscaPorId(int id)
        {
            return contexto.Posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Publica(int id)
        {
            var post = BuscaPorId(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            contexto.SaveChanges();
        }

    }
}