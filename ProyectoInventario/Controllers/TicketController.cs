using Microsoft.AspNetCore.Http;
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
    public class TicketController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    var lts = db.Ticket.OrderByDescending(d => d.fecha);
                    rpta.Exito = 1;
                    rpta.Data = lts;
                }

            }
            catch(Exception ex)
            {
                rpta.Mensaje = ex.Message;
            }
            return Ok(rpta);
        }

        [HttpPost]
        public IActionResult Post(Tickets model)
        {
            Require rpta = new Require();
            try
            {
                using(InventarioContext db = new InventarioContext())
                {
                    Tickets tk = new Tickets();
                    tk.fecha = DateTime.Now;
                    tk.UsuarioId = model.UsuarioId;
                    tk.Caso = model.Caso;
                    tk.Descripcion = model.Descripcion;
                    tk.EquipoId = model.EquipoId;
                    tk.TipoCasoId = model.TipoCasoId;
                    tk.Solucion = model.Solucion;
                    tk.Estado = model.Estado;

                    db.Ticket.Add(tk);
                    db.SaveChanges();
                }
                rpta.Exito = 1;

            }
            catch(Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = ex.Message;
            }

            return Ok(rpta);
        }

        [HttpPut]
        public IActionResult Edit(Tickets model)
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    Tickets tik = db.Ticket.Find(model.Id);
                    tik.Solucion = model.Solucion;
                    tik.Estado = model.Estado;

                    db.Entry(tik).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    rpta.Exito = 1;
                }
            }
            catch(Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = ex.Message;
            }
            return Ok(rpta);
        }
    }
}
