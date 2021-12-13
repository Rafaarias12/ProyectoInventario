using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoInventario.Models;
using ProyectoInventario.Models.Entidades;
using ProyectoInventario.Models.Request;
using ProyectoInventario.Models.Require;
using ProyectoInventario.Services;
using ProyectoInventario.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Require rpta = new Require();
            var userresponse = _userServices.Auth(model);

            if(userresponse == null)
            {
                rpta.Exito = 0;
                rpta.Mensaje = "Usuario o Contraseña Incorrecta";
                return BadRequest(rpta);
            }
            rpta.Exito = 1;
            rpta.Data = userresponse;
            return Ok(rpta);
        }
    }
}
