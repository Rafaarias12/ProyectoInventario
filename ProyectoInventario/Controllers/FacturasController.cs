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
    public class FacturasController : Controller
    {
        [HttpGet]
        public IActionResult Get(int Identificador)
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    var lts = (from s in db.Factura
                               where s.Id == Identificador
                               select s).FirstOrDefault();
                    rpta.Exito = 1;
                    rpta.Data = lts;
                }
            }
            catch(Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = ex.Message;
            }

            return Ok(rpta);
        }

        [HttpPost]
        public IActionResult Post(Facturas model)
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    Facturas fac = new Facturas();
                    fac.Proveedor = model.Proveedor;
                    fac.Fecha = model.Fecha;
                    fac.Documento = model.Documento;

                    db.Factura.Add(fac);
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
        public IActionResult Edit(Facturas model)
        {
            Require rpta = new Require();
            try
            {
                using(InventarioContext db = new InventarioContext())
                {
                    Facturas factura = db.Factura.Find(model.Id);
                    factura.Proveedor = model.Proveedor;
                    factura.Fecha = model.Fecha;
                    factura.Documento = model.Documento;

                    db.Entry(factura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
    }
}
