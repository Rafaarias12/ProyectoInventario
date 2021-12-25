using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.Models;
using ProyectoInventario.Models.Require;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoInventario.Models.Entidades;

namespace ProyectoInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegarController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    Delegar model = new Delegar();
                    var lts = db.Delegar.OrderByDescending(d => d.Fecha);
                    rpta.Data = lts;
                    rpta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                rpta.Mensaje = ex.Message;
            }

            return Ok(rpta);
        }
    }
}
