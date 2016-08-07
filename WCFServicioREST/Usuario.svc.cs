using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using WCFServicioREST.Dominio;
using WCFServicioREST.Persistencia;

namespace WCFServicioREST
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Usuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Usuario.svc o Usuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Usuario : IUsuario
    {
        private UsuarioDAO dao = new UsuarioDAO();

        //public UsuarioDominio Crear(UsuarioDominio usuarioCrear)
        //{
        //    //if ("jperez@gmail.com".Equals(usuarioCrear.Nombre))
        //    //{
        //    //    throw new WebFaultException<string>("Este correo ya existe.", HttpStatusCode.InternalServerError);
        //    //}
        //    return dao.Crear(usuarioCrear);
        //}

        public UsuarioDominio Obtener(string Correo)
        {
            return dao.Obtener(Correo);
        }

        public AccesoPerfilDominio ObtenerAcceso(string IdPerfil)
        {
            return dao.ObtenerAcceso(IdPerfil);
        }

        public bool CompararContrasena(string Contrasena)
        {
            bool Correcto = false;
            string stComprar = @"[A-ZÑ\s]";
            
            Match match = Regex.Match(Contrasena.Substring(0,1),stComprar);
            if (match.Success)
            {
                Correcto = true;
            }
            return Correcto;
        }

        public UsuarioDominio Traer(string Correo)
        {
            return dao.Traer(Correo);
        }
    }
}
