using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Column("idRol")]
        [Key]
        public int idRol { get; set; }
        [Required]
        [MaxLength(30)]
        [Column("nombre")]
        public string nombre { get; set; }
    }
}