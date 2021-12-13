using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Permisos
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public Rol Role { get; set; }
        [Column(TypeName = "int")]
        public Modulo Modulo { get; set; }
        public string Acceso { get; set; }
    }
}
