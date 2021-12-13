using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.Models;
using ProyectoInventario.Models.Require;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            Require rpta = new Require();
            try
            {
                using(InventarioContext db = new InventarioContext())
                {
                    var lst = db.Actas.OrderByDescending(d => d.Id).ToList();
                    rpta.Exito = 1;
                    rpta.Data = lst;
                }
            }
            catch(Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = Convert.ToString(ex);
            }

            return Ok(rpta);
        }

        [HttpPost]
        public IActionResult Post(Acta model)
        {
            Require rpta = new Require();
            try
            {
                using(InventarioContext db = new InventarioContext())
                {
                    Acta oActa = new Acta();
                    oActa.EquipoId = model.EquipoId;
                    oActa.UserId = model.UserId;
                    oActa.Documento = model.Documento;
                    oActa.FechaEntrega = model.FechaEntrega;

                    db.Actas.Add(oActa);
                    db.SaveChanges();
                }
                rpta.Exito = 1;
            }
            catch(Exception ex)
            {
                rpta.Mensaje = ex.Message;
            }
            return Ok(rpta);
        }
    }
}
