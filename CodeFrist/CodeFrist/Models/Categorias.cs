using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFrist.Models
{
    public class Categorias
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }

    public class Posts
    {
        [Key]
        public long PostID { get; set; }
        public string TituloPost { get; set; }
        public string ResumoPost { get; set; }
        public string ConteudoPost { get; set; }
        public DateTime DataPostagem { get; set; }
        public int CategoriaID { get; set; }
        [ForeignKey("CategoriaID")]
        public virtual Categorias Categorias
        {
            get; set;
        }
    }

    public class BlogContext : DbContext
    {
        public DbSet<Posts> Posts { get; set; }            
        public DbSet<Categorias> Categorias { get; set; }
    }


}