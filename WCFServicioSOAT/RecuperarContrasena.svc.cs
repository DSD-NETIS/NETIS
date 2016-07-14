using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicioSOAT.Persistencia;

namespace WCFServicioSOAT
{
    public class RecuperarContrasena : IRecuperarContrasena
    {
        RecuperarContrasenaDAO recuperarContrasenaDAO = new RecuperarContrasenaDAO();

        public string RecuperarContrasenaUsuario(string stCorreo)
        {
            return recuperarContrasenaDAO.RecuperarContrasena(stCorreo);
        }
    }
}
