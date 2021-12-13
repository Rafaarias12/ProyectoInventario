using ProyectoInventario.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models
{
    public class Acta
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }


        [Column(TypeName = "int")]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        
        [Column(TypeName = "int")]
        public int UserId { get; set; }
        public Users User { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FechaEntrega { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Documento { get; set; }


    }
}
