using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Intentos
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public Users Usuario { get; set; }
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }


    }
}
