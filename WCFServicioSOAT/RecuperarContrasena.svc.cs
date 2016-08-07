using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicioSOAT.Dominio;
using WCFServicioSOAT.Persistencia;

namespace WCFServicioSOAT
{
    public class RecuperarContrasena : IRecuperarContrasena
    {
        RecuperarContrasenaDAO recuperarContrasenaDAO = new RecuperarContrasenaDAO();

        public string RecuperarContrasenaUsuario(string stCorreo)
        {
            string stMensaje = recuperarContrasenaDAO.RecuperarContrasena(stCorreo);
            UsuarioDominio usuarioDominio = recuperarContrasenaDAO.Obtener(stCorreo);
            string rutaCola = @".\private$\EChuan";
            if (!MessageQueue.Exists(rutaCola))
            {
                MessageQueue.Create(rutaCola);
            }
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "Cambio Contraseña";
            mensaje.Body = new UsuarioDominio() { Nombre = usuarioDominio.Nombre, Apellido = usuarioDominio.Apellido, Correo = usuarioDominio.Correo, Contraseña = usuarioDominio.Contraseña };
            cola.Send(mensaje);
            return stMensaje;
        }
    }
}
