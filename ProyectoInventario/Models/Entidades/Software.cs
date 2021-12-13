using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Software
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Tipo { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Descripcion { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Clave { get; set; }

        [Column(TypeName = "int")]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FechaEquipo { get; set; }
    }
}
