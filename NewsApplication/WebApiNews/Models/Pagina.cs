using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    [Table("Pagina")]
    public class Pagina

    {
        [Key]
        [Column("idPage")]
        public int idPage { get; set; }
        [Column("pageSize")]
        public int pageSize { get; set; }
    }
}