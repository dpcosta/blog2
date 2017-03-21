using System;

namespace BlogTeste2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public bool Publicado { get; set; }
        public DateTime? DataPublicacao { get; set; }
    }
}