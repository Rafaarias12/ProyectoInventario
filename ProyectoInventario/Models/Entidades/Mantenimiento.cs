using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Mantenimiento
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Documento { get; set; }
    }
}
