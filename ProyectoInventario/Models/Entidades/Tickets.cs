using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Tickets
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime fecha { get; set; }

        [Column(TypeName = "int")]
        public int UsuarioId { get; set; }
        public Users Usuario { get; set; }

        [Column(TypeName = "int")]
        public int EquipoId { get; set; }
        public Equipo Equipo { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Descripcion { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TipoCasoId { get; set; }
        public TipoTickets TipoCaso { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Caso { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Solucion { get; set; }

        [Column(TypeName = "int")]
        public int Estado { get; set; }
    }
}
