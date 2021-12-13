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
        public IActionResult Edit(Tickets model)
        {

        }
    }
}
