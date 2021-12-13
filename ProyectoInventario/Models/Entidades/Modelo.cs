using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Modelo
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Marca { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Procesador { get; set; }

        [Column(TypeName ="varchar(45)")]
        public string Descripcion { get; set; }


        public ICollection<Equipo> Equipo { get; set; }
    }
}
