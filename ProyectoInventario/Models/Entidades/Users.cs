using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Users
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Cedula { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Apellido { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Correo { get; set; }

        [Column(TypeName = "varchar(45)")]
        [Required]
        public string Usuario { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Contraseña { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int RolesId { get; set; }
        public Rol Roles { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Estado { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Cargo { get; set; }

        public ICollection<Acta> Acta {get; set;}
        //public ICollection<Equipo> Equipo { get; set; }
        public ICollection<Intentos> Intentos { get; set; }


    }
}
