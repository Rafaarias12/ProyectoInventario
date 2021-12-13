using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Rol
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Descripcion { get; set; }
        public ICollection<Users> Usuarios { get; set; }
        public ICollection<Permisos> Permisos { get; set; }
    }
}
