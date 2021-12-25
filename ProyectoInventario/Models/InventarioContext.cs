using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoInventario.Models.Entidades;

namespace ProyectoInventario.Models
{
    public class InventarioContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Facturas> Factura { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Acta> Actas { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Software> Aplicaciones { get; set; }
        public DbSet<Users> Usuarios { get; set; }
        public DbSet<Tickets> Ticket { get; set; }
        public DbSet<TipoTickets> TipoTicket { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Permisos> Permiso { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Intentos> IntentosUsuarios { get; set; }
        public DbSet<Delegar> Delegar { get; set; }
        public DbSet<Administrador> AdminUser { get; set; }
        public object Modelo { get; internal set; }

        //public string connectionString;
        //public void Configuration(IConfiguration configuration)
        //{
        //    connectionString = configuration.GetConnectionString("DefaultConnection");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder opcion)
        {
            if (!opcion.IsConfigured)
            {
                const string connectionString = "Data Source=BG-AUX-SISTEMAS\\SQLEXPRESS;Initial Catalog=InventarioPrueba;Persist Security Info=True;User ID=sa;Password=Bio123456";
                opcion.UseSqlServer(connectionString);
            }
        }
    }
}
