using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoInventario.Models.Require
{
    public class Require
    {
        public int Exito { get; set; }

        public string Mensaje { get; set; }

        public object Data { get; set; }

        public Require()
        {
            this.Exito = 0;
        }
    }
}
