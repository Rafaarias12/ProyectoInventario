using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Entidades
{
    public class Equipo
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        //[Required]
        [Column(TypeName = "varchar(45)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        [Required]
        [Column(TypeName = "varchar(45)")]
        public string Serial { get; set; }

        [Required]
        [Column(TypeName ="varchar(45)")]
        public string TipoEquipo { get; set; }

        [Column(TypeName = "int")]
        public int Memoria { get; set; }

        [Column(TypeName = "int")]
        public int Disco { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string TipoMemoria { get; set; }

        [Column(TypeName = "int")]
        public int TipoDisco { get; set; }

        [Column(TypeName = "int")]
        public int Teclado { get; set; }

        [Column(TypeName = "varchar(45)")]
        public int Otro { get; set; }

        [Column(TypeName = "int")]
        public int Mouse { get; set; }

        [Column(TypeName = "int")]
        public int Multifuncional { get; set; }

        [Column(TypeName = "int")]
        public int Extension { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string SistemaOperativo { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Ip { get; set; }

        //[Required]
        //[Column(TypeName = "int")]
        //public int UsuarioId { get; set; }
        //public Users Usuario { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string HojaVida { get; set; }

        [Column(TypeName = "int")]
        public int Estado { get; set; }

        [Column(TypeName = "int")]
        public int FacturaId { get; set; }
        public Facturas Factura { get; set; }

        public ICollection<Acta> Acta { get; set; }

        public ICollection<Software> Software { get; set; }

        public ICollection<Mantenimiento> Mantenimiento { get; set; }

        public ICollection<Tickets> Ticket { get; set; }

    }
}
