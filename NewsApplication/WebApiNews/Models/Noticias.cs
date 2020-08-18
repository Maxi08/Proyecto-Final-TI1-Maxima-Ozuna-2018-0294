using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    [Table("Noticias")]
    public class Noticias
    {
        [Column("idNoticia")]
        [Key]
        public int idNoticia { get; set; }
        [Column("titular")]
        [Required]
        [MaxLength(100)]
        public string titular { get; set; }
        [Column("Portada")]
        [Required]
        public string Portada { get; set; }
        [Column("Resumen")]
        [Required]
        [MaxLength(500)]
        public string Resumen { get; set; }
        [Column("Contenido")]
        [Required]
        public string Contenido { get; set; }

        [Column("idCategoria")]
        [Required]

        public int idCategoria { get; set; }

        [Column("autor")]
        [Required]

        public string autor { get; set; }
        [Column("fecha_creacion")]
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Column("fecha_publicacion")]
       

        public DateTime fecha_publicacion { get; set; }
        [Column("idEstado")]
        [Required]
        public int idEstado { get; set; }
        [Column("eliminado")]
        public Boolean eliminado { get; set; }
    }
}