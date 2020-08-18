using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Column("idUsuario")]
        [Key]

        public int idUsuario { get; set; }
        [Column("nombre")]
        [MaxLength(30)]
        public string nombre { get; set; }
        [Column("apellido")]
        [MaxLength(30)]
        public string apellido { get; set; }
        [Column("email")]
        [MaxLength(50)]
        public string email { get; set; }
        [Column("contraseña")]
        [MaxLength(350)]
        public string contraseña { get; set; }

        [Column("rol")]
        public int rol { get; set; }
        [Column("eliminado")]
        
        public bool eliminado { get; set; }
        [Column("fecha_creacion")]
        public DateTime fecha_creacion { get; set; }
    }
}