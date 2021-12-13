using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Facturas
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Proveedor { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Documento { get; set; }

        public ICollection<Equipo> Equipos { get; set; }
    }
}
