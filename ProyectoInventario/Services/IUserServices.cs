using ProyectoInventario.Models;
using ProyectoInventario.Models.Request;
using ProyectoInventario.Models.Require;
using ProyectoInventario.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Services
{
    public interface IUserServices
    {
        UserResponse Auth(AuthRequest model);
    }
}
