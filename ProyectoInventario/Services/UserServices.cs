using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProyectoInventario.Common;
using ProyectoInventario.Models;
using ProyectoInventario.Models.Request;
using ProyectoInventario.Models.Require;
using ProyectoInventario.Tools;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProyectoInventario.Models.Entidades;

namespace ProyectoInventario.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppSettings _appSettings;

        public UserServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userresponse = new UserResponse();
            using (var db = new InventarioContext())
            {
                string spassword = Encript.GetSHA256(model.Password);

                var usuario = db.Usuarios.Where(d => d.Usuario == model.Usuario &&
                                                d.Contraseña == spassword).FirstOrDefault();

                if (usuario == null) return null;

                userresponse.UserName = model.Usuario;
                userresponse.Token = GetToken(usuario);
            }

            return userresponse;
        }

        private string GetToken(Users usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Correo)
                    }
                 ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        
        }
    }
}
