using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.Models;
using ProyectoInventario.Models.Entidades;
using ProyectoInventario.Models.Require;
using ProyectoInventario.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult GetUsuarios()
        {
            Require rpta = new Require();
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    var usuario = db.Usuarios;
                    var roles = db.Roles;

                    var lts = (from u in usuario
                               join r in roles
                               on u.RolesId equals r.Id
                               select new
                               {
                                   Nombre = u.Nombre + u.Apellido,
                                   Usuario = u.Usuario,
                                   Cedula = u.Cedula,
                                   Correo = u.Correo,
                                   Rol = r.Descripcion,
                                   Activo = u.Estado
                               }
                               ).ToList();


                    rpta.Exito = 1;
                    rpta.Data = lts;
                }

            }
            catch (Exception ex)
            {
                rpta.Mensaje = Convert.ToString(ex);
            }
            return Ok(rpta);
        }

        [HttpPost]
        public IActionResult Post(Users model)
        {
            Require rpta = new Require();
            string pass = Encript.GetSHA256(model.Contraseña);
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    Users Usuario = new Users();
                    Usuario.Cedula = model.Cedula;
                    Usuario.Nombre = model.Nombre;
                    Usuario.Apellido = model.Apellido;
                    Usuario.Usuario = model.Usuario;
                    //Usuario.Contraseña = model.Contraseña;
                    Usuario.Contraseña = pass;
                    Usuario.Estado = model.Estado;
                    Usuario.RolesId = model.RolesId;
                    Usuario.Correo = model.Correo;

                    db.Usuarios.Add(Usuario);
                    db.SaveChanges();
                }

                rpta.Exito = 1;
            }
            catch (Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = Convert.ToString(ex);
            }
            return Ok(rpta);
        }

        [HttpPut]
        public IActionResult Edit(Users model)
        {
            Require rpta = new Require();
            string pass = Encript.GetSHA256(model.Contraseña);
            try
            {
                using (InventarioContext db = new InventarioContext())
                {
                    Users Usuario = db.Usuarios.Find(model.Id);

                    Usuario.Cedula = model.Cedula;
                    Usuario.Nombre = model.Nombre;
                    Usuario.Apellido = model.Apellido;
                    Usuario.Usuario = model.Usuario;
                    //Usuario.Contraseña = model.Contraseña;
                    Usuario.Contraseña = pass;
                    Usuario.Estado = model.Estado;
                    Usuario.RolesId = model.RolesId;
                    Usuario.Correo = model.Correo;

                    db.Entry(Usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }

                rpta.Exito = 1;
            }
            catch (Exception ex)
            {
                rpta.Exito = 0;
                rpta.Mensaje = Convert.ToString(ex);
            }
            return Ok(rpta);
        }

        //[HttpPost("Restore")]
        //public IActionResult Restablecer(string clave)
        //{
        //    return Ok("PruebaExito");
        //}

        //[HttpPut("Active")]
        //public IActionResult Activar(int Id)
        //{
        //    return Ok("PruebaExito");
        //}
    }
}
