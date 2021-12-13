using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.Models;
using ProyectoInventario.Models.Entidades;
using ProyectoInventario.Models.Require;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : Controller
    {
        [HttpGet]
        public IActionResult Get(string Tipo)
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    var usuario = db.Usuarios;
                    var factura = db.Factura;
                    var modelo = db.Modelos;
                    var actas = db.Actas;
                    var equipo = db.Equipos;

                    var lts = (from eq in equipo
                               
                               join act in actas
                               on eq.Id equals act.EquipoId
                               join fac in factura
                               on eq.FacturaId equals fac.Id
                               join mod in modelo
                               on eq.ModeloId equals mod.Id
                               join usu in usuario
                               on act.UserId equals usu.Id
                               
                               where eq.TipoEquipo.Equals(Tipo)
                               
                               select new
                               {
                                   Host = eq.Nombre,
                                   Usuario = usu.Nombre + usu.Apellido,
                                   Marca = mod.Marca,
                                   Modelo = mod.Descripcion,
                                   Serial = eq.Serial,
                                   Procesador = mod.Procesador,
                                   Memoria = eq.Memoria,
                                   TipoMemoria = eq.TipoMemoria,
                                   Disco = eq.Disco,
                                   TipoDisco = eq.TipoDisco,
                                   Teclado = eq.Teclado,
                                   Mouse = eq.Mouse,
                                   SO = eq.SistemaOperativo,
                                   Ip = eq.Ip

                               }
                               ).ToList();

                    rpta.Data = lts;
                    rpta.Exito = 1;
                }
                return Ok(rpta);
            }
            catch (Exception ex)
            {
                rpta.Mensaje = (Convert.ToString(ex));
                rpta.Exito = 0;
                return Ok(rpta);
            }
        }

        [HttpPost]
        public IActionResult Post(Equipo model)
        {
            Require rpta = new Require();
            try
            {
                Equipo equipo = new Equipo();
                using(InventarioContext db = new InventarioContext())
                {
                    equipo.Nombre = model.Nombre;
                    equipo.ModeloId = model.ModeloId;
                    equipo.Serial = model.Serial;
                    equipo.TipoDisco = model.TipoDisco;
                    equipo.Disco = model.Disco;
                    equipo.TipoEquipo = model.TipoEquipo;
                    equipo.TipoMemoria = model.TipoMemoria;
                    equipo.Memoria = model.Memoria;
                    equipo.Teclado = model.Teclado;
                    equipo.Mouse = model.Mouse;
                    equipo.Otro = model.Otro;
                    equipo.Multifuncional = model.Multifuncional;
                    equipo.Extension = model.Extension;
                    equipo.SistemaOperativo = model.SistemaOperativo;
                    equipo.Ip = model.Ip;
                    //equipo.UsuarioId = model.UsuarioId;
                    equipo.FacturaId = model.FacturaId;

                    db.Equipos.Add(equipo);
                    db.SaveChanges();
                }
                rpta.Exito = 1;
            }
            catch(Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = Convert.ToString(ex);
            }
            return Ok(rpta);
        }

        [HttpPut]
        public IActionResult Edit(Equipo model)
        {
            Require rpta = new Require();
            try
            {
                
                using (InventarioContext db = new InventarioContext())
                {
                    Equipo equipo = db.Equipos.Find(model.Id);
                    equipo.Nombre = model.Nombre;
                    equipo.ModeloId = model.ModeloId;
                    equipo.Serial = model.Serial;
                    equipo.TipoDisco = model.TipoDisco;
                    equipo.Disco = model.Disco;
                    equipo.TipoEquipo = model.TipoEquipo;
                    equipo.TipoMemoria = model.TipoMemoria;
                    equipo.Memoria = model.Memoria;
                    equipo.Teclado = model.Teclado;
                    equipo.Mouse = model.Mouse;
                    equipo.Otro = model.Otro;
                    equipo.Multifuncional = model.Multifuncional;
                    equipo.Extension = model.Extension;
                    equipo.SistemaOperativo = model.SistemaOperativo;
                    equipo.Ip = model.Ip;
                    //equipo.UsuarioId = model.UsuarioId;
                    equipo.FacturaId = model.FacturaId;

                    db.Entry(equipo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                rpta.Exito = 1;
            }
            catch(Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = Convert.ToString(ex);
            }
            return Ok(rpta);
        }
        
        //No se eliminan equipos, se desactivan.
    }
}
