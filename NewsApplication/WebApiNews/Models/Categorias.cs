using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    [Table("Categorias")]
    public class Categorias
    {   
        [Column("idCategoria")]
        [Key]
        public int idCategoria { get; set; }
        [Required]
        [MaxLength(50)]
        [Column("nombre")]
        public string nombre { get; set; }
        [Column("eliminado")]
        public Boolean eliminado { get; set; }
    }
}