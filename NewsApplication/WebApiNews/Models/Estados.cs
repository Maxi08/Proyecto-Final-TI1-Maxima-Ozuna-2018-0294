using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiNews.Models
{
    [Table("Estados")]
    public class Estados
    {
        [Column("idEstado")]
        [Key]
        public int idEstado { get; set; }
        [Column("nombre")]
        [MaxLength(30)]
        [Required]
        public string nombre { get; set; }

    }
}