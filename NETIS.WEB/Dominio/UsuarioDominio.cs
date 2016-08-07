using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NETIS.WEB.Dominio
{
    public class UsuarioDominio
    {
        public string IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}