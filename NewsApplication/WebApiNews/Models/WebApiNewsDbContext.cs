using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    public class WebApiNewsDbContext : DbContext
    {
        public WebApiNewsDbContext()
           : base("name=DefaultConnection")
        {
        }
        public static WebApiNewsDbContext Create()
        {
            return new WebApiNewsDbContext();
        }
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Noticias> noticias { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Estados> estados { get; set; }

        public System.Data.Entity.DbSet<WebApiNews.Models.Pagina> Paginas { get; set; }
    }
}